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
```

## Views

- **Main view**  
    As a new user you're greeted with a 'Welcome' view, where you can go to either 'Books' or a 'Privacy' sub-website.
![image](https://github.com/user-attachments/assets/51eebce3-bec1-4676-a2df-95e9aab4b303)


- **User Login**
    Users with accounts can login by typing providing their email and password. By checking 'Remember me' checkbox they allow the website to remember their data while logging.
<img width="941" alt="image" src="https://github.com/user-attachments/assets/ec54e25f-c2fb-407f-a5fd-8126442cc629" />
![image](https://github.com/user-attachments/assets/c875096e-a192-4dc0-baf7-658638761670)


- **User Registration**
    New users have the ability to make an account by providing their email, password and confirmation of the password.


- **Forgotten password**
   If the user has forgotten their password there is a possibility of resetting their password.


  - **After logging or registration**
   After logging in users receive access to the book list and can use the search bar to find books by title or author (search is case-insensitive) or sort books by title, author or publish date. Prices are displayed in both PLN and USD - the app fetches live currency data from the NBP API.


- **Add new books**
  They can add new books with title, author, price, date, and availability.


- **Edit or delete books**
  Edit or delete existing books. Each book is stored in the central database, visible in a shared list.


- **Change status of a book**
  For each book, users can choose "Already read" or "On the bookshelf" if they plan to read this book in the future.
  These statuses are: saved per user, visible only to the logged-in user, easily changed with a single click.


- **Accordion filter**
  Filter books with an accordion interface: show only read books or show only to-read books. Users can change the status of those books in accordion.


  









