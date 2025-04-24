using BookStore.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStore.Data;

public class BookStoreDbContext(DbContextOptions<BookStoreDbContext> options) : DbContext(options)
{
    public DbSet<Book> Books => Set <Book>();
}