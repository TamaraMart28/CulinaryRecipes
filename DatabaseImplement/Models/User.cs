using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class User
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public string AvatarName { get; set; }

        public string AvatarPath { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Recipe> Recipes { get; set; }

        [ForeignKey("UserId")]
        public virtual List<Selection> Selections { get; set; }

        [ForeignKey("UserId")]
        public virtual List<CommentGrade> CommentGrades { get; set; }

        [ForeignKey("UserIdFollower")]
        public virtual List<Subscription> SubscriptionFollowers { get; set; }

        [NotMapped]
        [ForeignKey("UserIdFollowing")]
        public virtual List<Subscription> SubscriptionFollowings { get; set; }
    }
}
