using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClodeMonnetV2.Model;

public class Order
{
    public Order()
    {
        OrderItems = new List<OrderItem>();
    }
    public int OrderId { get; set; }
    public int UserId { get; set; }
    public string? OrderStatus { get; set; }
    public DateTime OrderTime { get; set; }
    [ForeignKey("UserId")]
    public virtual User? User { get; set; }
    public virtual ICollection<OrderItem>? OrderItems { get; set; }
}