using System.Collections.Generic;

namespace ClodeMonnetV2.Model;

public sealed class Dish
{
    public Dish(ICollection<Menu> menus, ICollection<OrderItem> orderItems)
    {
        Menus = menus;
        OrderItems = orderItems;
    }
    public Dish() { }

    public int DishId { get; set; }
    public string? DishName { get; set; }
    public decimal Price { get; set; }
    public string? Category { get; set; }
    public string? Ingredients { get; set; }
    public string? ImagePath { get; set; }

    public ICollection<Menu>? Menus { get; set; }
    public ICollection<OrderItem>? OrderItems { get; set; }
}