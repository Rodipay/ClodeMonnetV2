using System;
using System.Collections.Generic;

namespace ClodeMonnetV2.Model;

public sealed class Order
{
    public Order(User user, ICollection<OrderItem> orderItems)
    { ;
        User = user;
        OrderItems = orderItems;
    }
    public Order() {}

    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string? OrderStatus { get; set; }
    public DateTime OrderTime { get; set; }

    public User? User { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}