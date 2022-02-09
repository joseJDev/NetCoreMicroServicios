using System;

namespace Ecommerce.Micro.CarShop.Application
{
    public class CarShopDetailDTO
    {
        public Guid? BookId { get; set; }
        public string TitleBook { get; set; }
        public string AuthorBook { get; set; }
        public DateTime? DatePublicBook { get; set; }
    }
}
