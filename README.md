# BookManager

**BookManager** is a web application built with ASP.NET Core MVC that allows users to manage their personal library. Each registered user can track which books they have read or plan to read — all stored securely in a database. The app also fetches the current USD exchange rate from an external API.

---

## Features

- Add, edit, and delete books (title, author, price, date, availability)
- Search books by title or author (case-insensitive)
- Sort books by title, author or publish date
- Pagination using `X.PagedList`
- Fetches real-time USD exchange rate from NBP API
- SQLite as the database
- Accordion-based filtering of books by status (already read / to-read)

## Extra Features

- Register and log in with ASP.NET Core Identity -> Allows users to store their preferences in a secure way
- Mark books as "Already read" or "On the bookshelf" — user-specific and private
- UI with Bootstrap 5 + glassmorphism styles
- Accordion-based filtering of books by status (already read / On the bookshelf)

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
- Optional: [Visual Studio Code](https://code.visualstudio.com/)

### Installation

```bash
git clone https://github.com/kamilabla/book_list_.NEt.git
cd BookManager
dotnet restore
dotnet ef database update
dotnet run
Then open the app in your browser at https://localhost:XXXX 
```

## Views

- **Main view**  <br/>
    As a new user you're greeted with a **`Welcome`** view, where you can go to either **`Home`** or a **`Books`** sub-website. <br/>
![image](https://github.com/user-attachments/assets/51eebce3-bec1-4676-a2df-95e9aab4b303)


- **User Login** <br/>
    Users with accounts can login by typing their email and password in the type-boxes. By checking **`Remember me`** checkbox they allow the website to remember their data while logging. <br/>
<img width="941" alt="image" src="https://github.com/user-attachments/assets/ec54e25f-c2fb-407f-a5fd-8126442cc629" />


- **User Registration** <br/>
    New users have the ability to make an account by providing their email, password and confirmation of the password. <br/>
![image](https://github.com/user-attachments/assets/f7246906-26ad-4ed2-8ecc-ac5f7f91c076)


  - **After logging or registering** <br/>
    After logging in users receive access to the book list and can use the search bar to find books by title or author by typing a phrase and clicking **`Search`** (search is case-insensitive) or sort books by title, author or publish date by clicking either **`Title`**, **`Author`** or **`Date`**. Prices are displayed in both PLN and USD - the app fetches live currency data from the NBP API. <br/>
![image](https://github.com/user-attachments/assets/d652f3ab-19d2-47a3-b4be-cde1a4b1857f)



    ![image](https://github.com/user-attachments/assets/7b46ec64-9ae2-4c88-907f-f70fa4bd1eda)


- **Add new books** <br/>
  They can add new books with title, author, price, date, and availability.  <br/>
![image](https://github.com/user-attachments/assets/e7ae7c80-1e27-4fd4-a193-23c2010ce184)


- **Edit or delete books** <br/>
  Edit or delete existing books. Each book is stored in the central database, visible in a shared list. <br/>
![image](https://github.com/user-attachments/assets/31e78441-c73d-4ac4-9694-0f7a1c318b9e)
![image](https://github.com/user-attachments/assets/c6d50948-bb3e-4664-8cac-65cbbc1bde52)


- **Change status of a book** <br/>
  For each book, users can choose "Already read" or "On the bookshelf" if they plan to read this book in the future.
  These statuses are: saved per user, visible only to the logged-in user, easily changed with a single click. <br/>
![image](https://github.com/user-attachments/assets/9a4a82de-1db5-4672-a52d-bb0b418821e1)


- **Accordion filter** <br/>
  Filter books with an accordion interface: show only read books or show only to-read books. Users can change the status of those books in accordion. <br/>
![image](https://github.com/user-attachments/assets/781cd251-780f-4dc6-b73a-faae557a4b3f)



    ![image](https://github.com/user-attachments/assets/97c0beef-8de1-4c82-adc0-293e327269f3)


  


