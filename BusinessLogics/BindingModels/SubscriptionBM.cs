using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogics.BindingModels
{
    public class SubscriptionBM
    {
        public int? Id { get; set; }

        public int UserIdFollower { get; set; }

        public int UserIdFollowing { get; set; }
    }
}
