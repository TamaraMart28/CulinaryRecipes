using BusinessLogics.ViewModels;

namespace CulinaryRecipesApp.Models
{
    public class IndexViewModelForSelections
    {
        public IEnumerable<SelectionVM> Selections { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
