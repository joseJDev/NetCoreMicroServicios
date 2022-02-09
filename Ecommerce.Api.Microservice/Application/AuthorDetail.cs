using Ecommerce.Api.Microservice.Models;
using Ecommerce.Api.Microservice.Persistence;
using Microsoft.EntityFrameworkCore;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System;
using AutoMapper;

namespace Ecommerce.Api.Microservice.Application
{
    public class AuthorDetail
    {
        public class DetailAuthor : IRequest<AuthorDTO>
        {
            public string AuthorGuid { get; set; }
        }

        public class Handler : IRequestHandler<DetailAuthor, AuthorDTO>
        {
            private readonly ContextAuthor _context;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor context, IMapper mapper)
            {
                _context = context;
                _mapper = mapper;
            }

            public async Task<AuthorDTO> Handle(DetailAuthor request, CancellationToken cancellationToken)
            {
                var author = await _context.Author.Where(x => x.AuthorGuid == request.AuthorGuid).FirstOrDefaultAsync();
                var authorDTO = _mapper.Map<Author, AuthorDTO>(author);
                
                if (author == null) throw new Exception("No se Encontro");
                
                return authorDTO;
            }
        }
    }
}
