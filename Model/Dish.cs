using System.Collections.Generic;

namespace ClodeMonnetV2.Model;

public class Dish
{
    public int DishId { get; set; }
    public string? DishName { get; set; }
    public decimal? Price { get; set; }
    public string? Category { get; set; }
    public string? ImagePath { get; set; }
    public List<Ingredient>? Ingredients { get; set; }
}