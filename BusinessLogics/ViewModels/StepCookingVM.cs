using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.ViewModels
{
    public class StepCookingVM
    {
        public int Id { get; set; }

        public int NumberOrder { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public int RecipeId { get; set; }
    }
}
