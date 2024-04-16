using API.WebApiService.Entities;
using API.WebApiService.Interceptors;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace API.WebApiService.Controllers
{
    [Route("api/user_profile")]
    [ApiController]
    [JwtTokenFilter]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserProfileController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create_or_update")]
        public async Task<IActionResult> CreateUserProfile([FromBody] CreateActivityRequest request)
        {
            var createActivityResponse = await _mediator.Send(request);

            return Ok(createActivityResponse);
        }

        [HttpGet]
        public async Task<IActionResult> GetUserProfile(string actionId)
        {
            var getUserProfileResponse = await _mediator.Send(new GetUserProfileRequest());

            return Ok(getUserProfileResponse);
        }
    }
}
