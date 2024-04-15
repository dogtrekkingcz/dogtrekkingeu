using API.WebApiService.Entities;
using API.WebApiService.Interceptors;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace API.WebApiService.Controllers
{
    [Route("api/activities")]
    [ApiController]
    [JwtTokenFilter]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ActivitiesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityRequest request)
        {
            var createActivityResponse = await _mediator.Send(request);

            return Ok(createActivityResponse);
        }

        [HttpPost]
        [Route("update")]
        public async Task<IActionResult> UpdateActivity([FromBody] UpdateActivityRequest request)
        {
            var updateActivityResponse = await _mediator.Send(request);

            return Ok(updateActivityResponse);
        }

        [HttpGet]
        [Route("{actionId}")]
        public async Task<IActionResult> GetActivity(string actionId)
        {
            var getEntriesByActionResponse = await _mediator.Send(new GetEntriesByActionRequest { ActionId = actionId });

            return Ok(getEntriesByActionResponse);
        }
    }
}
