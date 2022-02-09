using Ecommerce.Micro.CarShop.Application;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Ecommerce.Micro.CarShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarShopController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CarShopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<ActionResult<Unit>> Register(RegisterCarShopSession.Execute data)
        {
            return await _mediator.Send(data);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CarShopDTO>> GetCarShop(int id)
        {
            return await _mediator.Send(new CarShopDetail.Execute { CarShopSessionId = id });
        }
    }
}
