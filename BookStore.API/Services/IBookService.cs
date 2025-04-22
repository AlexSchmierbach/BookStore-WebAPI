using BookStore.Models;

namespace BookStore.Services;

public interface IBookService
{
    IEnumerable<Book> GetAllBooks();
    Book? GetBookById(int id);
}