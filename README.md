# BookManager

**BookManager** is a web application built with ASP.NET Core MVC that allows users to manage their personal library. Each registered user can track which books they have read or plan to read — all stored securely in a database. The app also fetches the current USD exchange rate from an external API.

---

## Features

- Register and log in with ASP.NET Core Identity
- Add, edit, and delete books (title, author, price, date, availability)
- Mark books as "Read" or "Want to read" — user-specific and private
- Search books by title or author (case-insensitive)
- Sort books by title, author or publish date
- Pagination using `X.PagedList`
- Fetches real-time USD exchange rate from NBP API
- UI with Bootstrap 5 + glassmorphism styles
- SQLite as the database
- Accordion-based filtering of books by status (already read / to-read)

---

## Technologies

- [.NET 8](https://dotnet.microsoft.com/)
- ASP.NET Core MVC (Razor Views)
- Entity Framework Core (with SQLite)
- ASP.NET Core Identity (with UI scaffolding)
- Bootstrap 5
- X.PagedList
- DB Browser for SQLite

---

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download)
- Optional: [DB Browser for SQLite](https://sqlitebrowser.org/)

### Installation

```bash
git clone https://github.com/your-username/BookManager.git
cd BookManager
dotnet restore
dotnet ef database update
dotnet run
Then open the app in your browser at https://localhost:XXXX 

## Views

As a new user you're greeted with a 'Welcome' view, where you can go to either 'Books' or 'Privacy' sub-website.







