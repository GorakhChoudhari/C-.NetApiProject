using KE.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Repository.Interface
{
    public interface IEmployee
    {
        Task<IEnumerable<Developers>> GetDevelopers();
    }
}
