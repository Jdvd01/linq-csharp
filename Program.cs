LinqQueries queries = new();

// Get all books
queries.PrintBooks();

// Get books published after a specific year
queries.GetBooksAfterYear(2000);