using Ecommerce.Micro.Book.Models;
using Ecommerce.Micro.Book.Persistence;
using FluentValidation;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Ecommerce.Micro.Book.Application
{
    public class BookRegister
    {
        public class Execute : IRequest
        {
            public string Title { get; set; }
            public DateTime? CreatedDate { get; set; }
            public Guid? AuthorBook { get; set; }
        }

        public class ExecuteValidation : AbstractValidator<Execute>
        {
            public ExecuteValidation()
            {
                RuleFor(x => x.Title).NotEmpty();
                RuleFor(x => x.CreatedDate).NotEmpty();
                RuleFor(x => x.AuthorBook).NotEmpty();
            }
        }

        public class Handler : IRequestHandler<Execute>
        {
            private readonly ContextBook _context;

            public Handler(ContextBook context)
            {
                _context = context;
            }

            public async Task<Unit> Handle(Execute request, CancellationToken cancellationToken)
            {
                var book = new BookLibrary
                {
                    Title = request.Title,
                    CreatedDate = request.CreatedDate,
                    AuthorBook = request.AuthorBook
                };

                _context.BookLibrary.Add(book);

                var result = await _context.SaveChangesAsync();
                
                if(result > 0) return Unit.Value;

                throw new Exception("No se pudo guardar el libro");

            }
        }
    }

}
