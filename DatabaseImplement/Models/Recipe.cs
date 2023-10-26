using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Recipe
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string ImageName { get; set; }

        public string ImagePath { get; set; }

        public DateTime Timing { get; set; }

        public int PortionAmount { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public int UserId { get; set; }

        public virtual User User { get; set; }

        [ForeignKey("RecipeId")]
        public virtual List<CommentGrade> CommentGrades { get; set; }

        [ForeignKey("RecipeId")]
        public virtual List<StepCooking> StepCookings { get; set; }

        [ForeignKey("RecipeId")]
        public virtual List<RecipeIngredient> RecipeIngredients { get; set; }

    }
}
