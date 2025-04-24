using BookStore.Data;
using BookStore.Models;

namespace BookStore.Services;

public class BookService(BookStoreDbContext context) : IBookService
{
    public IEnumerable<Book> GetAllBooks() => context.Books.ToList();

    public Book? GetBookById(int id) => context.Books.Find(id);

    public Book CreateBook(Book book)
    {
        context.Books.Add(book);
        context.SaveChanges();
        
        return book;
    }

    public Book? UpdateBook(Book book)
    {
        var existing = context.Books.Find(book.Id);
        if (existing is null) return null;
        
        existing.Title = book.Title;
        existing.Author = book.Author;
        existing.Price = book.Price;
        
        context.SaveChanges();
        return existing;
    }

    public void DeleteBook(int id)
    {
        var book = context.Books.Find(id);
        if (book is null) return;
        context.Books.Remove(book);
        context.SaveChanges();
    }
}