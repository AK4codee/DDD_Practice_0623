using DDD.Practice.Domain.Aggregates.MessageAggregate;
using DDD.Practice.Domain.SeedWork;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Infrastructure.Repositories
{
    public class MessageRepository : IMessageRepository
    {
        private readonly SimpleDBContext _context;

        public MessageRepository(SimpleDBContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public IUnitOfWork UnitOfWork => _context;

        public MessageEntity Add(MessageEntity entity)
        {
            return _context.Messages.Add(entity).Entity;
        }

        public void Update(MessageEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }

        public void Delete(MessageEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }

        public async Task<MessageEntity> GetAsync(int id, CancellationToken cancellationToken)
        {
            return await _context.Messages.Where(p => p.Id == id).FirstOrDefaultAsync(cancellationToken);
        }
    }
}
