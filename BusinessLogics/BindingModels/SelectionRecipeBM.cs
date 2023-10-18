using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.BindingModels
{
    public class SelectionRecipeBM
    {
        public int? Id { get; set; }

        public int SelectionId { get; set; }

        public int RecipeId { get; set; }
    }
}
