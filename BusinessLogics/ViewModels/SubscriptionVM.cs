using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.ViewModels
{
    public class SubscriptionVM
    {
        public int Id { get; set; }

        public int UserIdFollower { get; set; }

        public int UserIdFollowing { get; set; }
    }
}
