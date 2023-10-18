using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.ViewModels
{
    public class RecipeIngredientVM
    {
        public int Id { get; set; }

        public int RecipeId { get; set; }

        public int IngredientId { get; set; }

        public string Amount { get; set; }
    }
}
