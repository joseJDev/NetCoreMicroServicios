using AutoMapper;
using Ecommerce.Api.Microservice.Models;
using Ecommerce.Api.Microservice.Persistence;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Api.Microservice.Application
{
    public class QueryAuthor
    {
        public class ListAuthor : IRequest<List<AuthorDTO>> { }

        public class Handler : IRequestHandler<ListAuthor, List<AuthorDTO>>
        {
            private readonly ContextAuthor _contextAuthor;
            private readonly IMapper _mapper;

            public Handler(ContextAuthor contextAuthor, IMapper mapper)
            {
                _contextAuthor = contextAuthor;
                _mapper = mapper;
            }

            public async Task<List<AuthorDTO>> Handle(ListAuthor request, CancellationToken cancellationToken)
            {
                var authors = await _contextAuthor.Author.ToListAsync();
                var authorsDTO = _mapper.Map<List<Author>, List<AuthorDTO>>(authors);
                return authorsDTO;
            }
        }
    }
}
