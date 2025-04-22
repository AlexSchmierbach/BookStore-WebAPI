using BookStore.Models;
using Microsoft.AspNetCore.Mvc;
using BookStore.Services;

namespace BookStore.Controllers;

[ApiController]
[Route("api/[controller]")]
public class BooksController(IBookService bookService) : ControllerBase
{
    // GET endpoint to retrieve all the books we currently have.
    [HttpGet]
    public IActionResult GetAllBooks() => Ok(bookService.GetAllBooks());

    // GET endpoint to retrieve a specific book by its Id.
    [HttpGet("{id}")]
    public IActionResult GetBookById(int id)
    {
        var book = bookService.GetBookById(id);

        return book == null ? NotFound() : Ok(book);
    }

    [HttpPost]
    public IActionResult CreateBook([FromBody] Book book)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        
        var createdBook = bookService.CreateBook(book);
        
        return CreatedAtAction(nameof(GetBookById), new { id = createdBook.Id }, createdBook);
    }
}