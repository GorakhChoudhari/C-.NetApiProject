using System;
using System.Collections.Generic;
using System.Data;
using System.Text;
using System.Threading.Tasks;

namespace KE.Repository.Infrastructure.Interface
{
    public interface   IUnitOfWork : IDisposable
    {
        IDbConnection Connection {get ;}
        IDbTransaction Transaction {get ;}
        Task Begin();
        Task Commit();
        Task Rollback();
    }
}
