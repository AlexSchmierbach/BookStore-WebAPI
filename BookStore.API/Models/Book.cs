using System.ComponentModel.DataAnnotations;

namespace BookStore.Models;

public class Book
{
    public int Id { get; set; }
    [Required]
    public string Title { get; set; } = "";
    [Required]
    public string Author { get; set; } = "";
    [Range(0.01, 1000)]
    public decimal Price { get; set; }
}