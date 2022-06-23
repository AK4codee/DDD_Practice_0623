using DDD.Practice.Domain.SeedWork;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Infrastructure.Extensions
{
    static class MediatorExtension
    {
        public static async Task DispatchDomainEventsAsync(this IMediator mediator, SimpleDBContext ctx)
        {
            var domainEntity = ctx.ChangeTracker.Entries<Entity>().Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());
            var domainEvents = domainEntity.SelectMany(x => x.Entity.DomainEvents).ToList();
            domainEntity.ToList().ForEach(entity => entity.Entity.ClearDomainEvents());
            try
            {
                foreach(var domainEvent in domainEvents)
                {
                    await mediator.Publish(domainEvent);
                }
            }
            catch(Exception ex)
            {
                var message = ex.ToString();
            }
        }
    }
}
