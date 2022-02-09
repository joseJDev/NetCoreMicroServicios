using System;

namespace Ecommerce.Micro.CarShop.Models
{
    public class CarShopSessionDetail
    {
        public int CarShopSessionDetailId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public string ProductSelected { get; set; }
        public int CarShopSessionId { get; set; }
        public CarShopSession CarShopSession { get; set; }
    }
}
