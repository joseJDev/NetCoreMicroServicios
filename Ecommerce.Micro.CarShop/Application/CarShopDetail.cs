using AutoMapper;
using Ecommerce.Micro.CarShop.Persistence;
using Ecommerce.Micro.CarShop.RemoteInterface;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Micro.CarShop.Application
{
    public class CarShopDetail
    {
        public class Execute : IRequest<CarShopDTO>
        {
            public int CarShopSessionId { get; set; }
        }

        public class Handler : IRequestHandler<Execute, CarShopDTO>
        {
            public readonly ContextCarShop _context;
            private readonly IBooksService _bookService;

            public Handler(ContextCarShop contextCarShop, IBooksService bookService)
            {
                _context = contextCarShop;
                _bookService = bookService;
            }
            public async Task<CarShopDTO> Handle(Execute request, CancellationToken cancellationToken)
            {
                var carShopSession = await _context.CarShopSession.FirstOrDefaultAsync(x => x.CarShopSessionId == request.CarShopSessionId);
                var carShopSessionDetail = await _context.CarShopSessionDetail.Where(x => x.CarShopSessionId == request.CarShopSessionId).ToListAsync();

                var listCarShopDetailDTO = new List<CarShopDetailDTO>();

                foreach(var book in carShopSessionDetail)
                {
                    var response = await _bookService.GetBook(new Guid(book.ProductSelected));
                    if (response.result)
                    {
                        var objBook = response.Book;
                        var carShopDetial = new CarShopDetailDTO
                        {
                            TitleBook = objBook.Title,
                            DatePublicBook = objBook.CreatedDate,
                            BookId = objBook.BookLibraryId
                        };

                        listCarShopDetailDTO.Add(carShopDetial);
                    }
                }

                var carShopSessionDTO = new CarShopDTO
                {
                    CarShopId = carShopSession.CarShopSessionId,
                    CreatedDateSession = carShopSession.CreatedDate,
                    Products = listCarShopDetailDTO
                };

                return carShopSessionDTO;

            }
        }
    }
}
