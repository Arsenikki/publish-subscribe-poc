using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Contracts;
using MassTransit;
using Microsoft.Extensions.Logging;

namespace Subi.Consumers
{
    public class WorkConsumer : IConsumer<WorkSubmitted>
    {
        private readonly ILogger<WorkConsumer> _logger;

        public WorkConsumer(ILogger<WorkConsumer> logger)
        {
            _logger = logger;
        }

        public async Task Consume(ConsumeContext<WorkSubmitted> context)
        {
            var message = context.Message;
            _logger.LogInformation($"Received work with id: {message.Id}");
            await Task.Delay(2000);
        }
    }
}
