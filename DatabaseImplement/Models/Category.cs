using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Category
    {
        public int Id { get; set; }

        public string Description { get; set; }

        [ForeignKey("CategoryId")]
        public virtual List<Recipe> Recipes { get; set; }
    }
}
