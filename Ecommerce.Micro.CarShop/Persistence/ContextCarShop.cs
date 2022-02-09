using Ecommerce.Micro.CarShop.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Micro.CarShop.Persistence
{
    public class ContextCarShop : DbContext
    {
        public ContextCarShop(DbContextOptions<ContextCarShop> options) : base(options) { }

        public DbSet<CarShopSession> CarShopSession { get; set; }
        public DbSet<CarShopSessionDetail> CarShopSessionDetail { get; set;}
    }
}
