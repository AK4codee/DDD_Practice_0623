using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Infrastructure.SeedWork
{
    public interface IUnitOfDapper : IDisposable
    {
        IDbConnection Master { get; }
        IDbConnection Slave { get; }
        IDbTransaction Transaction { get; }
        void BeginTransaction();
        void Commit();
        void Rollback();
    }
}
