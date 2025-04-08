using X.PagedList;

namespace BookManager.Models
{
    public class BooksViewModel
    {
        public IPagedList<Book> Books { get; set; }
        public decimal UsdRate { get; set; }
    }
}
