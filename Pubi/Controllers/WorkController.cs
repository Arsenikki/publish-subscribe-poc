using Contracts;
using MassTransit;
using Microsoft.AspNetCore.Mvc;

namespace Pubi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WorkController : ControllerBase
    {
        private readonly IPublishEndpoint _endpoint;
        private readonly ILogger<WorkController> _logger;

        public WorkController(IPublishEndpoint endpoint,ILogger<WorkController> logger)
        {
            _endpoint = endpoint;
            _logger = logger;
        }

        [HttpPost(Name = "PostWork")]
        public async Task<IActionResult> Post()
        {
            var workItem = new WorkSubmitted()
            {
                Id = Guid.NewGuid()
            };
            await _endpoint.Publish(workItem);
            _logger.LogInformation($"Published work with id: {workItem.Id}");
            return Ok(workItem);
        }
    }
}