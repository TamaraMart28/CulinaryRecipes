using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DatabaseImplement.Models
{
    public class Subscription
    {
        public int Id { get; set; }

        public int UserIdFollower { get; set; }

        [NotMapped]
        public int UserIdFollowing { get; set; }

        public virtual User UserFollower { get; set; }

        [NotMapped]
        public virtual User UserFollowing { get; set; }
    }
}
