using Ecommerce.Api.Microservice.Models;
using Ecommerce.Api.Microservice.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Api.Microservice.Application
{
    public class RegisterAuthor
    {
        public class Execute: IRequest
        {
            public int AuthorId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public DateTime? DateBirth { get; set; }

        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.FirstName).NotEmpty().NotNull();
                RuleFor(x => x.LastName).NotEmpty().NotNull();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {

            public readonly ContextAuthor _context;

            public Handler(ContextAuthor context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var author = new Author
                {
                    FirstName = request.FirstName,
                    LastName = request.LastName,
                    DateBirth = request.DateBirth,
                    AuthorGuid = Guid.NewGuid().ToString()
                };

                _context.Author.Add(author);
                var result = await _context.SaveChangesAsync();

                if(result > 0)
                {
                    return Unit.Value;
                }

                throw new Exception("No se pudo insertar el autor");
                
            }
        }
    }
}
