using System;
using System.Collections.Generic;

namespace ClodeMonnetV2.Model;

public class Order
{
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string? OrderStatus { get; set; }
    public DateTime OrderTime { get; set; }
    public User? User { get; set; }
    public List<OrderItem>? OrderItems { get; set; }
}