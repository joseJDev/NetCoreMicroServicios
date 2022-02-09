using System;
using System.Collections.Generic;

namespace Ecommerce.Micro.CarShop.Models
{
    public class CarShopSession
    {
        public int CarShopSessionId { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public ICollection<CarShopSessionDetail> ListDetail{ get; set; }
    }
}
