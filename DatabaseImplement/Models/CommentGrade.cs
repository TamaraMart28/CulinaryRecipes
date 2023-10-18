using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseImplement.Models
{
    public class CommentGrade
    {
        public int Id { get; set; }

        public string Comment { get; set; }

        public int Grade { get; set; }

        public int UserId { get; set; }

        public int RecipeId { get; set; }

        public virtual User User { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
