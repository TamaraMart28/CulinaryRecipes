using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.BindingModels
{
    public class CategoryBM
    {
        public int? Id { get; set; }

        public string Description { get; set; }

        public Dictionary<int, string> Recipes { get; set; }
    }
}
