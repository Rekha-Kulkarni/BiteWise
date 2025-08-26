using BitewiseClient.Models;
using Microsoft.EntityFrameworkCore;

namespace BitewiseClient.Data
{

    public static class SeedData
    {
        public static void Initialize(ApplicationDbContext context)
        {
            // Ensure database is created
            context.Database.EnsureCreated();

            // Check if any recipes exist
            if (context.Recipes.Any())
            {
                return;   // DB has been seeded
            }

            // Sample recipes
            var recipe1 = new Receipe
            {
                Name = "Pasta Primavera",
                Description = "A fresh pasta dish with vegetables",
                Calories = 400,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Pasta", Quantity = 200, Unit = "g" },
                    new Ingredient { Name = "Bell Pepper", Quantity = 100, Unit = "g" },
                    new Ingredient { Name = "Olive Oil", Quantity = 2, Unit = "tbsp" }
                    }
            };

            var recipe2 = new Receipe
            {
                Name = "Chicken Salad",
                Description = "Healthy chicken salad with greens",
                Calories = 350,
                Ingredients = new List<Ingredient>
                {
                    new Ingredient { Name = "Chicken Breast", Quantity = 150, Unit = "g" },
                    new Ingredient { Name = "Lettuce", Quantity = 50, Unit = "g" },
                    new Ingredient { Name = "Olive Oil", Quantity = 1, Unit = "tbsp" }
                }
            };

            context.Recipes.AddRange(recipe1, recipe2);
            context.SaveChanges();
        }
    }
}
