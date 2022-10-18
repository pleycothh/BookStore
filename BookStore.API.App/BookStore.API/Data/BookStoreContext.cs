using BookStore.API.Modesl;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BookStore.API.Data
{
    public class BookStoreContext : IdentityDbContext<ApplicationUser>
    {
        public BookStoreContext(DbContextOptions<BookStoreContext> options)
            : base(options) // <- pass all the option from base class
        {
        }

        public DbSet<Books> Books { get; set; } // create new table called Boooks

        
    }
}
