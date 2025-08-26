using BitewiseClient.Models;

namespace BitewiseClient.Services
{
    using BitewiseClient.Models;
    public class ShoppingListService
    {
        private readonly List<Ingredient> _shoppingList = new();
 
        public IReadOnlyList<Ingredient> GetShoppingList() => _shoppingList;


        public IReadOnlyList<Ingredient> GetItems() => _shoppingList.AsReadOnly();

        public void AddItem(Ingredient ingredient)
        {
            // Optional: check for duplicates
            var existing = _shoppingList.FirstOrDefault(i => i.Name == ingredient.Name);
            if (existing == null)
            {
                _shoppingList.Add(new Ingredient
                {
                    Name = ingredient.Name,
                    Quantity = ingredient.Quantity,
                    Unit = ingredient.Unit
                });
            }
        }
        public void AddIngredients(IEnumerable<Ingredient> ingredients)
        {
            foreach (var ing in ingredients)
            {
                var existing = _shoppingList
                    .FirstOrDefault(i => i.Name.Equals(ing.Name, StringComparison.OrdinalIgnoreCase)
                                      && i.Unit.Equals(ing.Unit, StringComparison.OrdinalIgnoreCase));

                if (existing != null)
                {
                    // Sum quantity if ingredient already exists
                    existing.Quantity += ing.Quantity;
                }
                else
                {
                    // Add a new ingredient
                    _shoppingList.Add(new Ingredient
                    {
                        Name = ing.Name,
                        Quantity = ing.Quantity,
                        Unit = ing.Unit
                    });
                }
            }
        }
        public void Clear() => _shoppingList.Clear();
    }
}




