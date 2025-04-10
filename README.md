# BookManager 📚

A simple ASP.NET Core MVC app to manage personal books with read/to-read tracking per user.

## Features
- Register/Login with Identity
- Add/edit/delete/list books
- Mark as "Read" or "Want to Read"
- Search, sorting and pagination
- Fetch live USD exchange rate from NBP API
- SQLite database (local)
- Clean UI with Bootstrap and custom styles

## Technologies
- ASP.NET Core MVC (.NET 8)
- Entity Framework Core
- Identity UI (Razor)
- X.PagedList
- SQLite

## Setup
1. Clone repo
2. Run:
   ```bash
   dotnet restore
   dotnet ef database update
   dotnet run
