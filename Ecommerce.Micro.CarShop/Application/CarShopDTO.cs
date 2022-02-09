using System;
using System.Collections.Generic;

namespace Ecommerce.Micro.CarShop.Application
{
    public class CarShopDTO
    {
        public int CarShopId { get; set; }
        public DateTime? CreatedDateSession { get; set; }
        public List<CarShopDetailDTO> Products { get; set; }
    }
}
