using API.WebApiService.Entities;
using API.WebApiService.Interceptors;
using Mediator;
using Microsoft.AspNetCore.Mvc;
using PetsOnTrail.Interfaces.Actions.Services;

namespace API.WebApiService.Controllers
{
    [Route("api/activities")]
    [ApiController]
    [JwtTokenFilter]
    public class ActivitiesController : ControllerBase
    {
        private readonly IMediator _mediator;
        private readonly ICurrentUserIdService _currentUserIdService;

        public ActivitiesController(IMediator mediator, ICurrentUserIdService currentUserIdService)
        {
            _mediator = mediator;
            _currentUserIdService = currentUserIdService;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateActivity([FromBody] CreateActivityRequest request)
        {
            request.UserId = _currentUserIdService.GetUserId();

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
