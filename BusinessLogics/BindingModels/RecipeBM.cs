using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.BindingModels
{
    public class RecipeBM
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public DateTime Timing { get; set; }

        public int PortionAmount { get; set; }

        public int CategoryId { get; set; }

        public int UserId { get; set; }

        public Dictionary<int, string> CommentGrades { get; set; }

        public Dictionary<int, string> StepCookings { get; set; }

        public Dictionary<int, string> RecipeIngredients { get; set; }
    }
}
