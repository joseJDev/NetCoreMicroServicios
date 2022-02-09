using AutoMapper;
using Ecommerce.Micro.Book.Models;
using Ecommerce.Micro.Book.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Micro.Book.Application
{
    public class BookList
    {
        public class Execute : IRequest<List<BookLibraryDTO>> { }

        public class Handler : IRequestHandler<Execute, List<BookLibraryDTO>>
        {
            private readonly ContextBook _context;
            private readonly IMapper _mapper;

            public Handler(ContextBook context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }
            public async Task<List<BookLibraryDTO>> Handle(Execute request, CancellationToken cancellationToken)
            {
                var books = await _context.BookLibrary.ToListAsync();
                var booksDTO = _mapper.Map<List<BookLibrary>, List<BookLibraryDTO>>(books);
                return booksDTO;
            }
        }
    }
}
