using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessTracker.Domain.Interfaces
{
    public interface IUser<Tkey>
    {
        Tkey Id { get; set; }
        string UserName { get; set; }
        string Email { get; set; }
    }
}
