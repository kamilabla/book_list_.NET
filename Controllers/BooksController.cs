using Microsoft.AspNetCore.Mvc;
using BookManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookManager.Services;
using X.PagedList;
using X.PagedList.Extensions;
using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace BookManager.Controllers
{   
    [Authorize]
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CurrencyService _currencyService;

        public BooksController(AppDbContext context, CurrencyService currencyService)
        {
            _context = context;
            _currencyService = currencyService;
        }
        
        

        public async Task<IActionResult> Index(string sortOrder, string currentFilter, string searchString, int? page)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["AuthorSortParm"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";
            ViewData["CurrentFilter"] = searchString;

            var books = from b in _context.Books select b;

            if (!String.IsNullOrEmpty(searchString))
            {
                books = books.Where(s => s.Author.ToLower().Contains(searchString)
                                    || s.Title.ToLower().Contains(searchString));
            }

            // SORTOWANIE (jeśli masz)
            switch (sortOrder)
            {
                case "title_desc":
                    books = books.OrderByDescending(b => b.Title);
                    break;
                case "Author":
                    books = books.OrderBy(b => b.Author);
                    break;
                case "author_desc":
                    books = books.OrderByDescending(b => b.Author);
                    break;
                case "Date":
                    books = books.OrderBy(b => b.PublishDate);
                    break;
                case "date_desc":
                    books = books.OrderByDescending(b => b.PublishDate);
                    break;
                default:
                    books = books.OrderBy(b => b.Title);
                    break;
            }

                var rate = await _currencyService.GetUsdRateAsync();
                decimal usdRate = rate?.Rates?[0].Mid ?? 0;


                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                var statuses = _context.UserBookStatuses
                    .Where(s => s.UserId == userId)
                    .ToList();

                var allBooks = await _context.Books.ToListAsync();
           

                // Książki przeczytane i do przeczytania (pełne listy, nie stronicowane!)
                var readBooks = allBooks.Where(b => statuses.Any(s => s.BookId == b.Id && s.IsRead)).ToList();
                var wantBooks = allBooks.Where(b => statuses.Any(s => s.BookId == b.Id && s.WantToRead)).ToList();

                ViewBag.ReadBooks = readBooks;
                ViewBag.WantBooks = wantBooks;
                ViewBag.Statuses = statuses;
                ViewBag.UsdRate = rate?.Rates?[0].Mid ?? 1;


                
                int pageSize = 5;
                int pageNumber = page ?? 1; 


                var pagedList = books.ToList().ToPagedList(pageNumber, pageSize);

                var viewModel = new BooksViewModel
                {
                    Books = pagedList,
                    UsdRate = usdRate,
                    Statuses = statuses
                };

            


                return View(viewModel);
        }




        public IActionResult Create() => View();

        [HttpPost]
        public async Task<IActionResult> Create(Book book)
        {
            if (ModelState.IsValid)
            {
                _context.Books.Add(book);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(book);
        }

        public async Task<IActionResult> Edit(int id)
        {
            var book = await _context.Books.FindAsync(id);
            return book == null ? NotFound() : View(book);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(Book book)
        {
            _context.Books.Update(book);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var book = await _context.Books.FindAsync(id);
            if (book != null)
            {
                _context.Books.Remove(book);
                await _context.SaveChangesAsync();
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [Authorize]
        public IActionResult SetStatus(int bookId, string actionType)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

            var status = _context.UserBookStatuses
                .FirstOrDefault(s => s.BookId == bookId && s.UserId == userId);

            if (status == null)
            {
                status = new UserBookStatus
                {
                    UserId = userId,
                    BookId = bookId
                };
                _context.UserBookStatuses.Add(status);
            }

            // Toggle logic
            if (actionType == "read")
            {
                status.IsRead = !status.IsRead;
                if (status.IsRead)
                    status.WantToRead = false; // tylko jedno może być aktywne
            }
            else if (actionType == "want")
            {
                status.WantToRead = !status.WantToRead;
                if (status.WantToRead)
                    status.IsRead = false;
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
