using System.ComponentModel.DataAnnotations.Schema;

namespace ClodeMonnetV2.Model;

public class OrderItem
{
    public int OrderId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
    [ForeignKey("OrderId")]
    public virtual Order? Order { get; set; }
    [ForeignKey("DishId")]
    public virtual Dish? Dish { get; set; }
}