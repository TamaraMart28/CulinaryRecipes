using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.BindingModels
{
    public class SelectionBM
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public bool IsPrivate { get; set; }

        public int UserId { get; set; }
    }
}
