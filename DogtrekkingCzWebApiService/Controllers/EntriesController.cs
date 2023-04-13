using DogtrekkingCzWebApiService.Entities;
using Mediator;
using Microsoft.AspNetCore.Mvc;

namespace DogtrekkingCzWebApiService.Controllers
{
    [Route("api/entries")]
    [ApiController]
    public class EntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public EntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("create")]
        public async Task<IActionResult> CreateEntry([FromBody] CreateEntryRequest request)
        {
            var createEntryResponse = await _mediator.Send(request);

            return Ok(createEntryResponse);
        }

        [HttpGet]
        [Route("{actionId}")]
        public async Task<IActionResult> GetEntriesByAction(string actionId)
        {
            var getEntriesByActionResponse = await _mediator.Send(new GetEntriesByActionRequest { ActionId = actionId });

            return Ok(getEntriesByActionResponse);
        }
    }
}
