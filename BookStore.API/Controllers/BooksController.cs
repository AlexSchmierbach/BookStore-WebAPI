using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.Services;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    // GET: /api/books : Retrieve all books
    [HttpGet]
    public ActionResult<IEnumerable<Book>> GetAllBooks()
    {
        var books = bookService.GetAllBooks();
        return Ok(books);
    }

    // GET: /api/books/{id} : Retrieve a specific book by ID
    [HttpGet("{id}")]
    public ActionResult<Book> GetBookById(int id)
    {
        var book = bookService.GetBookById(id);
        if  (book is null) return NotFound();

        return Ok(book);
    }

    // POST: /api/books : Add a new book
    [HttpPost]
    public ActionResult<Book> CreateBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);
        
        var createdBook = bookService.CreateBook(book);
        
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }

    // PUT: /api/books/{id} : Update an existing book
    [HttpPut("{id}")]
    public IActionResult UpdateBook(int id, Book book)
    {
        if (id != book.Id)
            return BadRequest("ID in path and body must match.");
        
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var updated = bookService.UpdateBook(book);
        if (updated is null)
            return NotFound();
        
        return NoContent();
    }
    
    // DELETE: /api/books/{id} : Delete a book
    [HttpDelete("{id}")]
    public IActionResult DeleteBook(int id)
    {
        var existing = bookService.GetBookById(id);
        if (existing is null) return NotFound();
        
        bookService.DeleteBook(id);
        return NoContent();
    }
}