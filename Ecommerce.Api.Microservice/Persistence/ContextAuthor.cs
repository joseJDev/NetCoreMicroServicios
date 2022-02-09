using Ecommerce.Api.Microservice.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Api.Microservice.Persistence
{
    public class ContextAuthor : DbContext
    {
        public ContextAuthor(DbContextOptions<ContextAuthor> options) : base(options) { }

        public DbSet<Author> Author { get; set; }
        public DbSet<GradeAcademic> GradeAcademic { get; set; }
    }
}
