using BusinessLogics.ViewModels;

namespace CulinaryRecipesApp.Models
{
    public class IndexViewModelForRecipes
    {
        public IEnumerable<RecipeVM> Recipes { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
