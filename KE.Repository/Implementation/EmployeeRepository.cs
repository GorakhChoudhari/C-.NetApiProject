using KE.Framework.Models.Settings;
using KE.Repository.Helpers;
using KE.Repository.Infrastructure.Interface;
using Microsoft.Extensions.Options;
using KE.Models.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KE.Repository.Interface;

namespace KE.Repository.Implementation
{
    public class EmployeeRepository :BaseRepository,IEmployee
    {
        private const string IdQuery = "@TicketTypes";
        public EmployeeRepository(
            IOptions<DatabaseAdvancedSettingsOptions> settingsOptions,
                       IQueryBuilder queryBuilder,
            IUnitOfWork unitOfWork) : base(settingsOptions, queryBuilder, unitOfWork, TableNames.TicketType, IdQuery)
        {
            //_unitOfWork = unitOfWork;//
        }

        public async Task<IEnumerable<Developers>> GetDevelopers()
        {
            return await QueryProcedureAsync<Developers>("usp_GetDevelopers");
        }


    }
}
