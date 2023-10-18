using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.ViewModels
{
    public class UserVM
    {
        public int Id { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        public string Nickname { get; set; }

        public string AvatarName { get; set; }

        public string AvatarPath { get; set; }

        public Dictionary<int, string> Recipes { get; set; }

        public Dictionary<int, string> Selections { get; set; }

        public Dictionary<int, string> CommentGrades { get; set; }

        public Dictionary<int, string> SubscriptionFollowers { get; set; }

        public Dictionary<int, string> SubscriptionFollowings { get; set; }
    }
}
