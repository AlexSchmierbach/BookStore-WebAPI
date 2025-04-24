using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    [StringLength(100, ErrorMessage = "Title can't be longer than  100 characters.")]
    public string Title { get; set; } = "";
    [Required]
    [StringLength(100, ErrorMessage = "Author can't be longer than  100 characters.")]
    public string Author { get; set; } = "";
    [Range(0, 1000, ErrorMessage = "Price must be between 0 and 1000")]
    public decimal Price { get; set; }
}