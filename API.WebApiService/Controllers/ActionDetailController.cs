using API.WebApiService.Entities;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace API.WebApiService.Controllers
{
    [Route("api/actiondetail")]
    [ApiController]
    public class ActionDetailController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActionDetailController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetActionDetail(Guid id)
        {
            var actionDetail = await _mediator.Send(new ActionDetailRequest(id));
            return Ok(actionDetail);
        }
    }
}
