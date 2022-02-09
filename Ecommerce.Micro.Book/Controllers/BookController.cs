using Ecommerce.Micro.Book.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Micro.Book.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Register(BookRegister.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<BookLibraryDTO>>> GetAll()   
        {
            return await _mediator.Send(new BookList.Execute());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BookLibraryDTO>> Get(Guid id)
        {
            return await _mediator.Send(new BookDetail.DetailBook { BookLibraryId = id });
        }
    }
}
