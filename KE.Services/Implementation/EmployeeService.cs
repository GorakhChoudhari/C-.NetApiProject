using KE.Models.Common;
using KE.Repository.Interface;
using KE.Services.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KE.Services.Implementation
{
    public class EmployeeService : IEmployeeService
    {

        private readonly IEmployee _employeeRepository;

        public EmployeeService(IEmployee employeeRepository, IConfiguration configuration)
        {
            this._employeeRepository = employeeRepository;
        }
      public async Task<List<Developers>> GetDevelopers()
        {
            IEnumerable<Developers> developers;
            developers= await _employeeRepository.GetDevelopers();
            return developers.ToList();
        }
    }
}
