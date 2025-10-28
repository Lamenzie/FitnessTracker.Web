using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FitnessTracker.Domain.Entities
{
    public abstract class Entity<TKey> : Interfaces.IEntity<TKey>
    {
        [Key]
        public TKey Id { get; set; }
    }
}
