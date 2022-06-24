using DDD.Practice.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Domain.Aggregates.MessageAggregate
{
    // 定義外部可對此 Aggregate 有哪些操作，在 Infrastructure 層實作
    public interface IMessageRepository : IRepository<MessageEntity>
    {
        MessageEntity Add(MessageEntity entity);
        void Update(MessageEntity entity);
        void Delete(MessageEntity entity);
        Task<MessageEntity> GetAsync(int id, CancellationToken cancellationToken);
    }
}
