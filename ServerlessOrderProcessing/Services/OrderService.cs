using ServerlessOrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessOrderProcessing.Services
{
    public class OrderService:IOrderService
    {
        public Order CreateOrder(CreateOrderRequest request)
        {
            return new Order
            {
                OrderId = Guid.NewGuid(),
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Status = "Created",
                CreatedAt = DateTime.UtcNow
            };
        }

    }
}
