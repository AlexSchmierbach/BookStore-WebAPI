using BookStore.Data;
using BookStore.Middleware;
using BookStore.Models;
using BookStore.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add DbContext
builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.Configure<AppInfo>(
    builder.Configuration.GetSection("AppInfo")
    );
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Custom Middleware
app.UseGlobalExceptionHandler();
app.UseRequestLogging();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

// Optional data seeding
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<BookStoreDbContext>();
    db.Database.EnsureCreated();

    if (!db.Books.Any())
    {
        db.Books.AddRange(
            new Book { Title = "Clean Code", Author = "Robert C. Martin", Price = 39.99M },
            new Book { Title = "Domain-Driven Design", Author = "Eric Evans", Price = 54.99M }
        );
        db.SaveChanges();
    }
}

app.Run();