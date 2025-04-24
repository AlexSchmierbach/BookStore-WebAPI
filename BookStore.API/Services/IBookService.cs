using BookStore.Models;

namespace BookStore.Services;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book? GetBookById(int id);
    Book CreateBook(Book book);
    Book? UpdateBook(Book book);
    void DeleteBook(int id);
}