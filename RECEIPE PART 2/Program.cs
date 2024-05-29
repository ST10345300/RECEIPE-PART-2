class Program
{
    static RecipeManager recipeManager = new RecipeManager();

    static void Main(string[] args)
    {
        recipeManager.OnCalorieExceeded += NotifyCalorieExceeded;

        bool running = true;

        while (running)
        {
            Console.WriteLine("Recipe Manager");
            Console.WriteLine("1. Enter a new recipe");
            Console.WriteLine("2. Display all recipes");
            Console.WriteLine("3. Display a specific recipe");
            Console.WriteLine("4. Scale a recipe");
            Console.WriteLine("5. Reset recipe quantities");
            Console.WriteLine("6. Clear all recipes");
            Console.WriteLine("7. Exit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    EnterNewRecipe();
                    break;
                case "2":
                    recipeManager.DisplayAllRecipes();
                    break;
                case "3":
                    DisplaySpecificRecipe();
                    break;
                case "4":
                    ScaleRecipe();
                    break;
                case "5":
                    ResetRecipeQuantities();
                    break;
                case "6":
                    recipeManager.Recipes.Clear();
                    Console.WriteLine("All recipes cleared.");
                    break;
                case "7":
                    running = false;
                    break;
                default:
                    Console.WriteLine("Invalid option. Please try again.");
                    break;
            }
        }
    }

    static void EnterNewRecipe()
    {
        Console.Write("Enter recipe name: ");
        string name = Console.ReadLine();

        Console.Write("Enter number of ingredients: ");
        int numIngredients = int.Parse(Console.ReadLine());
        List<Ingredient> ingredients = new List<Ingredient>();

        for (int i = 0; i < numIngredients; i++)
        {
            Console.Write($"Enter ingredient {i + 1} name: ");
            string ingredientName = Console.ReadLine();

            Console.Write($"Enter ingredient {i + 1} quantity: ");
            double quantity = double.Parse(Console.ReadLine());

            Console.Write($"Enter ingredient {i + 1} unit: ");
            string unit = Console.ReadLine();

            Console.Write($"Enter ingredient {i + 1} calories: ");
            int calories = int.Parse(Console.ReadLine());

            Console.Write($"Enter ingredient {i + 1} food group: ");
            string foodGroup = Console.ReadLine();

            ingredients.Add(new Ingredient(ingredientName, quantity, unit, calories, foodGroup));
        }

        Console.Write("Enter number of steps: ");
        int numSteps = int.Parse(Console.ReadLine());
        List<string> steps = new List<string>();

        for (int i = 0; i < numSteps; i++)
        {
            Console.Write($"Enter step {i + 1} description: ");
            steps.Add(Console.ReadLine());
        }

        Recipe recipe = new Recipe(name, ingredients, steps);
        recipeManager.AddRecipe(recipe);
        Console.WriteLine("Recipe added successfully.");
    }

    static void DisplaySpecificRecipe()
    {
        Console.Write("Enter recipe name to display: ");
        string name = Console.ReadLine();

        Recipe recipe = recipeManager.GetRecipeByName(name);
        if (recipe == null)
        {
            Console.WriteLine("Recipe not found.");
            return;
        }

        recipe.Display();
    }

    static void ScaleRecipe()
    {
        Console.Write("Enter recipe name to scale: ");
        string name = Console.ReadLine();

        Recipe recipe = recipeManager.GetRecipeByName(name);
        if (recipe == null)
        {
            Console.WriteLine("Recipe not found.");
            return;
        }

        Console.Write("Enter scale factor (0.5, 2, 3): ");
        double factor = double.Parse(Console.ReadLine());

        recipe.ScaleRecipe(factor);
        Console.WriteLine("Recipe scaled successfully.");
    }

    static void ResetRecipeQuantities()
    {
        Console.Write("Enter recipe name to reset: ");
        string name = Console.ReadLine();

        Recipe recipe = recipeManager.GetRecipeByName(name);
        if (recipe == null)
        {
            Console.WriteLine("Recipe not found.");
            return;
        }

        recipe.ResetQuantities();
        Console.WriteLine("Recipe quantities reset successfully.");
    }

    static void NotifyCalorieExceeded(string message)
    {
        Console.WriteLine(message);
    }
}
