# BookStore

A simple but cleanly architected .NET 9 Web API for managing books.

---

## 📦 Tech Stack

- **.NET 9 Web API**
- **PostgreSQL** via Entity Framework Core (Npgsql)
- **EF Core In-Memory** for unit testing
- **xUnit** for service-level tests
- **Scalar** for REST API testing (works with Postman too)

---

## 🔗 Database

### ✅ Connected to PostgreSQL
- PostgreSQL is used as the primary database.
- Integrated using **Entity Framework Core** with the **Npgsql** provider.
- Connection string defined in `appsettings.json` under `"DefaultConnection"`.

---

## 📚 Book Entity (Model)

Represents a single book with:

| Property | Type    |
|----------|---------|
| Id       | int     |
| Title    | string  |
| Author   | string  |
| Price    | decimal |

---

## 🧱 Architecture

Structured with clean separation of concerns:

- `Models/` – data structures (e.g., `Book.cs`)
- `Services/` – business logic (e.g., `IBookService`, `BookService`)
- `Controllers/` – API endpoints
- `Data/` – EF Core `DbContext` (`BookContext`)
- Full support for **Dependency Injection**

---

## 📡 API Endpoints

| Method | Endpoint             | Description                     |
|--------|----------------------|---------------------------------|
| GET    | `/api/books`         | Retrieve all books              |
| GET    | `/api/books/{id}`    | Retrieve a specific book by ID  |
| POST   | `/api/books`         | Add a new book                  |
| PUT    | `/api/books/{id}`    | Update an existing book         |
| DELETE | `/api/books/{id}`    | Delete a book                   |

---

## ✅ Validation

All endpoints validate model inputs:
- Required fields: `Title`, `Author`, `Price`
- Price must be a positive decimal
- Returns proper **400 BadRequest** for invalid inputs

---

## 🧪 Unit Testing

- Service layer is tested with **xUnit** using an in-memory database
- Covers creating, updating, retrieving, and deleting books
- Ensures logic works independently from the database

---

## 🛠️ Migrations

- Managed using EF Core CLI:
  ```bash
  dotnet ef migrations add InitialCreate
  dotnet ef database update