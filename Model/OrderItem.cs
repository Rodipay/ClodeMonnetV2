namespace ClodeMonnetV2.Model;

public class OrderItem
{
    public int OrderId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }
    public virtual Order? Order { get; set; }
    public virtual Dish? Dish { get; set; }
}