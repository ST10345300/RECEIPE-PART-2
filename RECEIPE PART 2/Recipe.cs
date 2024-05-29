public class Recipe
{
    public string Name { get; set; }
    public List<Ingredient> Ingredients { get; set; }
    public List<string> Steps { get; set; }
    private List<Ingredient> originalIngredients;

    public Recipe(string name, List<Ingredient> ingredients, List<string> steps)
    {
        Name = name;
        Ingredients = ingredients;
        Steps = steps;
        originalIngredients = ingredients.Select(i => new Ingredient(i.Name, i.Quantity, i.Unit, i.Calories, i.FoodGroup)).ToList();
    }

    public void ScaleRecipe(double factor)
    {
        foreach (var ingredient in Ingredients)
        {
            ingredient.Quantity *= factor;
        }
    }

    public void ResetQuantities()
    {
        for (int i = 0; i < Ingredients.Count; i++)
        {
            Ingredients[i].Quantity = originalIngredients[i].Quantity;
        }
    }

    public int TotalCalories()
    {
        return Ingredients.Sum(ingredient => ingredient.Calories);
    }

    public void Display()
    {
        Console.WriteLine($"Recipe: {Name}");
        Console.WriteLine("Ingredients:");
        foreach (var ingredient in Ingredients)
        {
            Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name} ({ingredient.Calories} calories, {ingredient.FoodGroup})");
        }
        Console.WriteLine("Steps:");
        for (int i = 0; i < Steps.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {Steps[i]}");
        }
        Console.WriteLine($"Total Calories: {TotalCalories()}");
    }
}
