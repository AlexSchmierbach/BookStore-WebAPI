using BookStore.Models;

namespace BookStore.Services;

public class BookService : IBookService
{
    private readonly List<Book> _books = new()
    {
        new Book { Id = 1, Title = "Clean Code", Author = "Robert C. Martin", Price = 29.99m },
        new Book { Id = 2, Title = "The Pragmatic Programmer", Author = "Andy Hunt", Price = 35.00m }
    };
    
    public IEnumerable<Book> GetAllBooks() => _books;

    public Book? GetBookById(int id) => _books.FirstOrDefault(b => b.Id == id);
}