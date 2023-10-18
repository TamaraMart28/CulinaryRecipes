using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.ViewModels
{
    public class CategoryVM
    {
        public int Id { get; set; }

        public string Description { get; set; }

        public Dictionary<int, string> Recipes { get; set; }
    }
}
