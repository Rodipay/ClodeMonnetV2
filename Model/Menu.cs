namespace ClodeMonnetV2.Model;

public sealed class Menu
{
    public Menu(Dish dish)
    {
        Dish = dish;
    }
    public Menu() {}

    public int MenuId { get; set; }
    public int DishId { get; set; }
    public bool Available { get; set; }

    public Dish? Dish { get; set; }
}