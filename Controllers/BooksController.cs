using Microsoft.AspNetCore.Mvc;
using BookManager.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using BookManager.Services;

namespace BookManager.Controllers
{
    public class BooksController : Controller
    {
        private readonly AppDbContext _context;
        private readonly CurrencyService _currencyService;

        public BooksController(AppDbContext context, CurrencyService currencyService)
        {
            _context = context;
            _currencyService = currencyService;
        }

        
        public async Task<IActionResult> Index(string sortOrder)
        {
            ViewData["TitleSortParm"] = String.IsNullOrEmpty(sortOrder) ? "title_desc" : "";
            ViewData["AuthorSortParm"] = sortOrder == "Author" ? "author_desc" : "Author";
            ViewData["DateSortParm"] = sortOrder == "Date" ? "date_desc" : "Date";

            var books = from b in _context.Books select b;

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
            ViewBag.UsdRate = rate?.Rates?[0].Mid ?? 0;

            return View(await books.ToListAsync());
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
    }
}
