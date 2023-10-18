using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.ViewModels
{
    public class CommentGradeVM
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int Grade { get; set; }

        public int UserId { get; set; }

        public int RecipeId { get; set; }
    }
}
