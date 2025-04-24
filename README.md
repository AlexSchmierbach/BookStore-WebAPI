# BookStore

## Connected to PostgreSQL
- Uses PostgreSQL as the primary database
- Connected via Entity Framework Core using Npgsql
- Configured with a DefaultConnection string in appsettigns.json

## Book Entity (Model)
### Represents a book with properties:
- Id (int)
- Title (string)
- Author (string)
- Price (decimal)

## Architecture
### Clean separation of concerns:
- Models for data structure
- Services for business logic (IBookService + BookService)
- Controllers for API routing
- Full Supports Dependency Injection

## API Endpoints
|	Method	|	Endpoint	|	Description	|
|	------	|	--------	|	-----------	|
|	GET	|	/api/books	|	Retrieve all books	|
|	GET	|	/api/books/{id}	|	Retrieve a specific book by ID	|
|	POST	|	/api/books	|	Add a new book	|
|	PUT	|	/api/books/{id}	|	Update an existing book	|
|	DELETE	|	/api/books/{id}	|	Delete a book	|

## Other Features
- Currently tested with Scalar but can be tested with Postman, or any REST client
- Migrations are managed via EF Core
- Easily extensible with DTOs, or authentication layers