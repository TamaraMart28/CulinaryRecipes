using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Ingredient
    {
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("IngredientId")]
        public virtual List<RecipeIngredient> RecipeIngredients { get; set; }
    }
}
