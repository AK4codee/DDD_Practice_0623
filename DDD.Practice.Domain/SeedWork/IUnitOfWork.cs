using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Domain.SeedWork
{
    public interface IUnitOfWork
    {
        Task<bool> SaveEntityAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
