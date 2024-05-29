
public class RecipeTests
{
  
    public void TestTotalCalories()
    {
        // Arrange
        var ingredients = new List<Ingredient>
        {
            new Ingredient("Sugar", 100, "grams", 387, "Carbohydrates"),
            new Ingredient("Butter", 50, "grams", 717, "Fats")
        };
        var steps = new List<string> { "Mix ingredients", "Bake at 180 degrees for 20 minutes" };
        var recipe = new Recipe("Cake", ingredients, steps);

        // Act
        int totalCalories = recipe.TotalCalories();

        // Assert
        Assert.AreEqual(745, totalCalories);  // Corrected expected value based on ingredient calculation
    }
}
