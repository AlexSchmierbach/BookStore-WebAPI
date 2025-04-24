using BookStore.Data;
using BookStore.Models;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Tests;

public class BookServiceTests
{
    [Fact]
    public void Create_AddBooksToDatabaseTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BookStoreDbContext>()
            .UseInMemoryDatabase("TestDb")
            .Options;

        using var context = new BookStoreDbContext(options);
        var service = new BookService(context);

        var book = new Book
        {
            Title = "Clean Code",
            Author = "Robert C. Martin",
            Price = 42.00M
        };

        // Act
        var created = service.CreateBook(book);

        // Assert
        var books = context.Books.ToList();
        Assert.Single(books);
        Assert.Equal("Clean Code", books[0].Title);
    }

    [Fact]
    public void UpdateBook_ChangesBookValuesTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BookStoreDbContext>()
            .UseInMemoryDatabase("UpdateTestDb")
            .Options;

        using var context = new BookStoreDbContext(options);
        var service = new BookService(context);

        var original = new Book { Title = "Old Title", Author = "Author", Price = 10M };
        var created = service.CreateBook(original);

        var updated = new Book { Id = created.Id, Title = "New Title", Author = "New Author", Price = 20M };

        // Act
        var result = service.UpdateBook(updated);

        // Assert
        Assert.NotNull(result);
        Assert.Equal("New Title", result!.Title);
        Assert.Equal("New Author", result.Author);
        Assert.Equal(20M, result.Price);
    }

    [Fact]
    public void DeleteBook_RemovesBookTest()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<BookStoreDbContext>()
            .UseInMemoryDatabase("DeleteTestDb")
            .Options;

        using var context = new BookStoreDbContext(options);
        var service = new BookService(context);

        var book = new Book { Title = "Delete Me", Author = "Author", Price = 10M };
        var created = service.CreateBook(book);

        // Act
        service.DeleteBook(created.Id); // no return value

        var books = service.GetAllBooks();

        // Assert
        Assert.DoesNotContain(books, b => b.Id == created.Id);
    }
}
