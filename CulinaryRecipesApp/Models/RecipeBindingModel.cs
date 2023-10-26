namespace CulinaryRecipesApp.Models
{
    public class RecipeBindingModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public IFormFile Image { get; set; }
        public DateTime Timing { get; set; }
        public string Category { get; set; }
        public int PortionAmount { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<RecipeStep> RecipeSteps { get; set; }
    }

    public class RecipeStep
    {
        public string Description { get; set; }
        public IFormFile Photo { get; set; }
    }

    public class RecipeIngredient
    {
        public string Name { get; set; }
        public string Amount { get; set; }
    }
}
