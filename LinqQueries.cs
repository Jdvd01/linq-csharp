using System.Text.Json;

public class LinqQueries
{
    private List<Book> booksCollection = [];

    public LinqQueries()
    {
        using StreamReader reader = new("books.json");
        string json = reader.ReadToEnd();
        booksCollection = JsonSerializer.Deserialize<List<Book>>(
            json,
            new JsonSerializerOptions() { PropertyNameCaseInsensitive = true }
        ) ?? [];
    }

    public void GetAllBooks()
    {
        PrintBooks(booksCollection);
    }

    private static void PrintBooks(IEnumerable<Book> books)
    {
        string textFormat = "{0, -60} {1, 15} {2, 20}";
        Console.WriteLine($"{textFormat}\n", "Title", "Pages", "Published Date");
        foreach (var book in books)
        {
            Console.WriteLine($"{textFormat}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }

    public void GetBooksAfterYear(int year)
    {
        // Extension method
        IEnumerable<Book> books = booksCollection.Where(book => book.PublishedDate.Year > year);

        // Query method
        // IEnumerable<Book> books = from book in booksCollection
        //                             where book.PublishedDate.Year > year
        //                             select book;

        PrintBooks(books);
    }

    public void GetBooksWithSpecificTitleAndPageCount(string title, int pageCount)
    {
        // Extension method
        IEnumerable<Book> books = booksCollection.Where(
            book => book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && book.PageCount > pageCount);

        // Query method
        // IEnumerable<Book> books = from book in booksCollection
        //                                                 where book.Title.Contains(title, StringComparison.OrdinalIgnoreCase) && book.PageCount > pageCount
        //                                                 select book;

        PrintBooks(books);
    }
}