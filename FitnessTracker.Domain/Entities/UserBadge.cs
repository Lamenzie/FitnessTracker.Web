using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace FitnessTracker.Domain.Entities
{
    [Table("UserBadge")]
    public class UserBadge
    {
        public Guid UserId { get; set; }
        public int BadgeId { get; set; }
        public DateTime EarnedAt { get; set; }

        public User? User { get; set; }
        public Badge? Badge { get; set; }
    }
}
