using KE.Repository.Infrastructure.Interface;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace KE.Repository.Infrastructure
{
    public sealed class UnitOfWork : IUnitOfWork
    {
        private readonly IConnectionFactory connectionFactory;
        private SqlConnection connection;
        private readonly ILogger<UnitOfWork> logger;
        public UnitOfWork(IConnectionFactory connectionFactory, ILogger<UnitOfWork> logger)
        {
            this.logger = logger ?? throw new ArgumentNullException(nameof(logger));
            this.connectionFactory = connectionFactory ?? throw new ArgumentNullException(nameof(connectionFactory));
        }
        public IDbConnection Connection
        {
            get
            {
                if (connection is null)
                {
                    connection = (SqlConnection)connectionFactory.Connection;
                }
                return connection;
            }
            private set { connection = (SqlConnection)value; }
        }
        public IDbTransaction Transaction { get; private set; }

        public async Task Begin()
        {
            await OpenConnection();
            Transaction = await connection.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            if (Transaction != null)
            {
                await ((SqlTransaction)Transaction).CommitAsync();
            }
            await CloseConnection();
        }

        public void Dispose()
        {
            Transaction?.Dispose();
            Transaction = null;
            connection?.Dispose();
            connection = null;
        }

        public async Task Rollback()
        {
           
            if(Connection.State == ConnectionState.Open)
            {
                if(Transaction != null) { await ((SqlTransaction)Transaction).RollbackAsync(); }
            }
            await CloseConnection();
        }
        private async Task CloseConnection()
        {
            try
            {
                if (connection is null) return;
                if (connection.State == ConnectionState.Open) { await connection.CloseAsync(); }
            }
            catch (Exception exception)
            {

                logger.LogError(exception, "An error occured during  closing to the database");
            }
        }
        private async Task OpenConnection()
        {
            try
            {
                if (connection is null) connection = (SqlConnection)connectionFactory.Connection;
                if (connection.State != ConnectionState.Open) { await connection.OpenAsync(); }
            }
            catch (Exception exception)
            {

                logger.LogError(exception, "An error occured during  connecting to the database");
            }
        }
    }
}
