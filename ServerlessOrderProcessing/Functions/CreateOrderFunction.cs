using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Extensions.Logging;
using ServerlessOrderProcessing.Models;
using ServerlessOrderProcessing.Services;

namespace ServerlessOrderProcessing.Functions;

public class CreateOrderFunction
{
    private readonly ILogger<CreateOrderFunction> _logger;
    private readonly IOrderService _orderService;

    public CreateOrderFunction(
        ILogger<CreateOrderFunction> logger,
        IOrderService orderService)
    {
        _logger = logger;
        _orderService = orderService;
    }

    [Function("CreateOrder")]
    public async Task<HttpResponseData> Run(
        [HttpTrigger(
            AuthorizationLevel.Function,
            "post",
            Route = "orders")]
        HttpRequestData req)
    {
        _logger.LogInformation(
            "CreateOrder function triggered.");

        var request =
            await req.ReadFromJsonAsync<CreateOrderRequest>();

        if (request is null)
        {
            var response =
                req.CreateResponse(HttpStatusCode.BadRequest);

            await response.WriteAsJsonAsync(new
            {
                message = "Request body is required."
            });

            return response;
        }

        if (string.IsNullOrWhiteSpace(request.ProductId)
            || request.Quantity <= 0)
        {
            var response =
                req.CreateResponse(HttpStatusCode.BadRequest);

            await response.WriteAsJsonAsync(new
            {
                message =
                    "ProductId is required and Quantity must be greater than 0."
            });

            return response;
        }

        var order = _orderService.CreateOrder(request);

        _logger.LogInformation(
            "Order {OrderId} created.",
            order.OrderId);

        var createdResponse =
            req.CreateResponse(HttpStatusCode.Created);

        await createdResponse.WriteAsJsonAsync(order);

        return createdResponse;
    }
}