using AutoMapper;
using Ecommerce.Micro.Book.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using System;
using Ecommerce.Micro.Book.Models;

namespace Ecommerce.Micro.Book.Application
{
    public class BookDetail
    {
        public class DetailBook : IRequest<BookLibraryDTO>
        {
            public Guid BookLibraryId;
        }

        public class Handler : IRequestHandler<DetailBook, BookLibraryDTO>
        {
            private readonly IMapper _mapper;
            private readonly ContextBook _context;

            public Handler(IMapper mapper, ContextBook context)
            {
                _mapper = mapper;
                _context = context;
            }

            public async Task<BookLibraryDTO> Handle(DetailBook request, CancellationToken cancellationToken)
            {
                var author = await _context.BookLibrary.Where(x => x.BookLibraryId == request.BookLibraryId).FirstOrDefaultAsync();
                var authorDTO = _mapper.Map<BookLibrary, BookLibraryDTO>(author);
                return authorDTO;
            }
        }
    }
}
