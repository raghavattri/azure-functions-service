using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessOrderProcessing.Models
{
    public class CreateOrderRequest
    {
        public string ProductId { get; set; } = string.Empty;

        public int Quantity { get; set; }   
    }
}
