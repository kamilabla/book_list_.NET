using BookManager.Models;
using Microsoft.AspNetCore.Identity;

namespace BookManager.Models;

public class UserBookStatus
{
    public int Id { get; set; }

    public string UserId { get; set; }
    public IdentityUser User { get; set; }

    public int BookId { get; set; }
    public Book Book { get; set; }

    public bool IsRead { get; set; }
    public bool WantToRead { get; set; }
}
