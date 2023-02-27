using KE.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Services.Interface
{
    public interface IEmployeeService
    {
        Task<List<Developers>> GetDevelopers();
    }
}
