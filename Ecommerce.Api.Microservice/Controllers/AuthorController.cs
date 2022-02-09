using Ecommerce.Api.Microservice.Application;
using Ecommerce.Api.Microservice.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Ecommerce.Api.Microservice.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AuthorController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Register(RegisterAuthor.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> GetAll()
        {
            return await _mediator.Send(new QueryAuthor.ListAuthor());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AuthorDTO>> GetById(string id)
        {
            return await _mediator.Send(new AuthorDetail.DetailAuthor { AuthorGuid = id });

        }

    }
}
