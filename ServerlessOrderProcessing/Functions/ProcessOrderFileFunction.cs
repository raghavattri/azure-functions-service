using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace ServerlessOrderProcessing.Functions;

public class ProcessOrderFileFunction
{
    private readonly ILogger<ProcessOrderFileFunction> _logger;

    public ProcessOrderFileFunction(
        ILogger<ProcessOrderFileFunction> logger)
    {
        _logger = logger;
    }

    [Function("ProcessOrderFile")]
    public async Task Run(
        [BlobTrigger(
            "incoming-orders/{name}",
            Connection = "OrderStorageConnection")]
        Stream blobStream,
        string name)
    {
        _logger.LogInformation(
            "Blob trigger fired for file: {FileName}",
            name);

        _logger.LogInformation(
            "Blob size: {Size} bytes",
            blobStream.Length);

        using var reader = new StreamReader(blobStream);

        var content = await reader.ReadToEndAsync();

        _logger.LogInformation(
            "Processing completed for file: {FileName}",
            name);
    }
}