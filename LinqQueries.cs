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

    public IEnumerable<Book> GetAllBooks()
    {
        return booksCollection;
    }

    public void PrintBooks()
    {
        string textFormat = "{0, -60} {1, 15} {2, 20}";
        Console.WriteLine($"{textFormat}\n", "Title", "Pages", "Published Date");
        foreach (var book in booksCollection)
        {
            Console.WriteLine($"{textFormat}", book.Title, book.PageCount, book.PublishedDate.ToShortDateString());
        }
    }

    public IEnumerable<Book> GetBooksAfterYear(int year)
    {
        return booksCollection.Where(book => book.PublishedDate.Year > year);
    }


}