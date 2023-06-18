using System.Collections.Generic;

namespace ClodeMonnetV2.Model;

public class Ingredient
{
    public int IngredientId { get; set; }
    public string? IngredientName { get; set; }
    public int Quantity { get; set; }
    public virtual List<Dish>? Dishes { get; set; }
}