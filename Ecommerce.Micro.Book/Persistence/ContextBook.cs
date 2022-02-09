using Microsoft.EntityFrameworkCore;
using Ecommerce.Micro.Book.Models;

namespace Ecommerce.Micro.Book.Persistence
{
    public class ContextBook : DbContext
    {
        public ContextBook() { }

        public ContextBook(DbContextOptions<ContextBook> options) : base(options) { }
        
        public virtual DbSet<BookLibrary> BookLibrary { get; set; }
    }
}
