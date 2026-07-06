using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ServerlessOrderProcessing.Functions;

public class OrderCleanupFunction
{
    private readonly ILogger<OrderCleanupFunction> _logger;

    public OrderCleanupFunction(
        ILogger<OrderCleanupFunction> logger)
    {
        _logger = logger;
    }

    [Function("OrderCleanup")]
    public void Run(
        [TimerTrigger("0 */1 * * * *")] TimerInfo timer)
    {
        _logger.LogInformation(
            "Order cleanup executed at: {Time}",
            DateTime.UtcNow);

        if (timer.ScheduleStatus is not null)
        {
            _logger.LogInformation(
                "Next execution: {Next}",
                timer.ScheduleStatus.Next);
        }
    }
}