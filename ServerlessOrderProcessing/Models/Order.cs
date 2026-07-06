using System;
using System.Collections.Generic;
using System.Text;

namespace ServerlessOrderProcessing.Models;

public class Order
{
    public Guid OrderId { get; set; }

    public string ProductId { get; set; } = string.Empty;

    public int Quantity { get; set; }

    public string Status { get; set; } = string.Empty;

    public DateTime CreatedAt { get; set; }
}