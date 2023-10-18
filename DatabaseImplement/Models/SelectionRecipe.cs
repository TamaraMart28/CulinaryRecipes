using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    public class SelectionRecipe
    {
        public int? Id { get; set; }

        public int SelectionId { get; set; }

        public int RecipeId { get; set; }

        public virtual Selection Selection { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
