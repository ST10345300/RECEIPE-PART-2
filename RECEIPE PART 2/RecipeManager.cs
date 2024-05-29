public delegate void CalorieNotification(string message);

public class RecipeManager
{
    public List<Recipe> Recipes { get; set; }
    public event CalorieNotification OnCalorieExceeded;

    public RecipeManager()
    {
        Recipes = new List<Recipe>();
    }

    public void AddRecipe(Recipe recipe)
    {
        Recipes.Add(recipe);
        if (recipe.TotalCalories() > 300)
        {
            OnCalorieExceeded?.Invoke($"Warning: {recipe.Name} exceeds 300 calories!");
        }
    }

    public void DisplayAllRecipes()
    {
        var sortedRecipes = Recipes.OrderBy(r => r.Name).ToList();
        Console.WriteLine("Recipes in Alphabetical Order:");
        foreach (var recipe in sortedRecipes)
        {
            Console.WriteLine(recipe.Name);
        }
    }

    public Recipe GetRecipeByName(string name)
    {
        return Recipes.FirstOrDefault(r => r.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }
}
