using BitewiseClient.Services;
using Microsoft.AspNetCore.Mvc;

namespace BitewiseClient.Controllers
{

    public class ShoppingController : Controller
    {
        private readonly ShoppingListService _shoppingService;

        public ShoppingController(ShoppingListService shoppingService)
        {
            _shoppingService = shoppingService;
        }

        public IActionResult Index()
        {
            var list = _shoppingService.GetShoppingList();
            return View(list); // Views/Shopping/Index.cshtml
        }

        public IActionResult Clear()
        {
            _shoppingService.Clear();
            return RedirectToAction("Index");
        }
    }
}
