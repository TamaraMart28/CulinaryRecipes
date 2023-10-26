using BusinessLogics.ViewModels;

namespace CulinaryRecipesApp.Models
{
    public class RecipeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public int UserId { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string ImagePath { get; set; }
        public DateTime Timing { get; set; }
        public string Category { get; set; }
        public int PortionAmount { get; set; }
        public List<RecipeIngredient> RecipeIngredients { get; set; }
        public List<RecipeStepVM> RecipeSteps { get; set; }
        public List<ComGradeVM> CommentGrades { get; set; }
    }

    public class RecipeStepVM
    {
        public int Number { get; set; }
        public string Description { get; set; }
        public string PhotoPath { get; set; }
    }

    public class ComGradeVM
    {
        public int Grade { get; set; }
        public int UserId { get; set; }
        public string User { get; set; }
        public string Comment { get; set; }
    }
}
