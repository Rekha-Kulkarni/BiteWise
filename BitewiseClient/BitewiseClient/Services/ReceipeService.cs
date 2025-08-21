using BitewiseClient.Data;
using BitewiseClient.Models;
using Microsoft.EntityFrameworkCore;


namespace BitewiseClient.Services
{
    public class ReceipeService
    {

        private readonly ApplicationDbContext _context;

        public ReceipeService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get all recipes
        public async Task<List<Receipe>> GetAllRecipesAsync()
        {
            return await _context.Recipes
                                 .Include(r => r.Ingredients)
                                 .ToListAsync();
        }

        // Get a recipe by Id
        public async Task<Receipe?> GetRecipeByIdAsync(int id)
        {
            return await _context.Recipes
                                 .Include(r => r.Ingredients)
                                 .FirstOrDefaultAsync(r => r.Id == id);
        }

        // Add a new recipe
        public async Task<Receipe> AddRecipeAsync(Receipe recipe)
        {
            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();
            return recipe;
        }

        // Update an existing recipe
        public async Task<bool> UpdateRecipeAsync(Receipe recipe)
        {
            var existing = await _context.Recipes.FindAsync(recipe.Id);
            if (existing == null) return false;

            existing.Name = recipe.Name;
            existing.Description = recipe.Description;
            existing.Calories = recipe.Calories;
            // Update ingredients if needed
            existing.Ingredients = recipe.Ingredients;

            _context.Recipes.Update(existing);
            await _context.SaveChangesAsync();
            return true;
        }

        // Delete a recipe
        public async Task<bool> DeleteRecipeAsync(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe == null) return false;

            _context.Recipes.Remove(recipe);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}

