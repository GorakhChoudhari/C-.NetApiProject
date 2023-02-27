using Dapper;
using KE.Framework.Models.Settings;
using KE.Repository.Infrastructure.Interface;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace KE.Repository.Implementation
{
    public class BaseRepository
    {
        protected readonly IQueryBuilder _queryBuilder;
        private readonly IUnitOfWork _unitOfWork;
        protected readonly string _tableName;
        protected readonly int _commandTimeout;
        protected readonly string _idQuery;
        public BaseRepository(
            IOptions<DatabaseAdvancedSettingsOptions> settingsOptions,
            IQueryBuilder queryBuilder,
            IUnitOfWork unitOfWork,
            string tableName,
            string idQuery
            )
        {
            _queryBuilder = queryBuilder ?? throw new ArgumentNullException(nameof(queryBuilder));
            _unitOfWork = unitOfWork ?? throw new ArgumentNullException(nameof(unitOfWork));
            _tableName = tableName;
            _commandTimeout = (int)settingsOptions.Value.CommandTimeout.TotalSeconds;
            _idQuery = idQuery;
        }
        public virtual async Task<IEnumerable<T>> GetAllEntitiesAsync<T>()
        {
            var sql = _queryBuilder.GetAllQuery(_tableName);
            return await  _unitOfWork.Connection.QueryAsync<T>(sql,null,_unitOfWork.Transaction,_commandTimeout);
              
        }
        public virtual  async Task<IEnumerable<T>> QueryProcedureAsync<T> (string query,object parameters = null)
        {
            return await _unitOfWork.Connection.QueryAsync<T>(query, parameters, _unitOfWork.Transaction, _commandTimeout, CommandType.StoredProcedure);
        }
        public virtual async Task<IEnumerable<T>> Query<T>(string query, object parameters = null)
        {
            return await _unitOfWork.Connection.QueryAsync<T>(query, parameters, _unitOfWork.Transaction, _commandTimeout);
        }
        public virtual async Task<T> QueryFirstOrDefaultAsync<T>(string query, object parameters = null)
        {
            return await _unitOfWork.Connection.QueryFirstOrDefaultAsync<T>(query, parameters, _unitOfWork.Transaction, _commandTimeout);
        }
        public virtual async Task<T> QuerySingleOrDefaultAsync<T>(string query, object parameters = null)
        {
            return await _unitOfWork.Connection.QuerySingleOrDefaultAsync<T>(query, parameters, _unitOfWork.Transaction, _commandTimeout);
        }
        public virtual async Task<int>ExecuteProcedureAsync(string procedureName,object parameters)
        {
            return await _unitOfWork.Connection.ExecuteAsync(procedureName,parameters,_unitOfWork.Transaction, _commandTimeout,CommandType.StoredProcedure);
        }
        public virtual async Task<GridReader> QueryMultipleAsync(string procedureName, object parameters)
        {
            return await _unitOfWork.Connection.QueryMultipleAsync(procedureName, parameters, _unitOfWork.Transaction, _commandTimeout, CommandType.StoredProcedure);
        }
    }
}
