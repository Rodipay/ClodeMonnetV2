namespace ClodeMonnetV2.Model;

public sealed class OrderItem
{
    public OrderItem(int orderItemId, int orderId, int dishId, int quantity, Order order, Dish dish)
    {
        Order = order;
        Dish = dish;
    }
    public OrderItem() { }

    public int OrderItemId { get; set; }
    public int OrderId { get; set; }
    public int DishId { get; set; }
    public int Quantity { get; set; }

    public Order? Order { get; set; }
    public Dish? Dish { get; set; }
}