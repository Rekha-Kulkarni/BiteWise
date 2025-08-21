using BitewiseClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitewiseClient.Controllers
{
    public class ReceipeController : Controller
    {
        private readonly ReceipeService _recipeService;

        public ReceipeController(ReceipeService recipeService)
        {
            _recipeService = recipeService;
        }

        public IActionResult Index()
        {
            var recipes = _recipeService.GetAllRecipesAsync();
            return View(recipes);
        }
    }
}