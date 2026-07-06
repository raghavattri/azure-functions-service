using ServerlessOrderProcessing.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessOrderProcessing.Services
{
    public interface IOrderService
    {
        Order CreateOrder(CreateOrderRequest request);
    }
}
