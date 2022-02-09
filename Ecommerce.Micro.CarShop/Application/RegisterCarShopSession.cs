using Ecommerce.Micro.CarShop.Models;
using Ecommerce.Micro.CarShop.Persistence;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Micro.CarShop.Application
{
    public class RegisterCarShopSession
    {
        public class Execute : IRequest
        {
            public DateTime CreatedDate { get; set; }
            public List<string> Products { get; set; }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ContextCarShop _context;

            public Handler(ContextCarShop context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var carShopSession = new CarShopSession()
                {
                    CreatedDate = request.CreatedDate
                };

                _context.CarShopSession.Add(carShopSession);
                var resultCarShopSession = await  _context.SaveChangesAsync();
                
                if (resultCarShopSession == 0) throw new Exception("Hubo un error en la insercion del carrito");

                int idCarShopSession = carShopSession.CarShopSessionId;
                
                foreach(var product in request.Products)
                {
                    var carShopSessionDetail = new CarShopSessionDetail()
                    {
                        CreatedDate = DateTime.Now,
                        CarShopSessionId = idCarShopSession,
                        ProductSelected = product
                    };

                    _context.CarShopSessionDetail.Add(carShopSessionDetail);
                }

                var resultCarShopSessionDetail = await _context.SaveChangesAsync();
                if (resultCarShopSessionDetail == 0) throw new Exception("Hubo un error en la insercion del carrito");
                
                return Unit.Value;
            }
        }
    }
}
