using DDD.Practice.Domain.Aggregates.MessageAggregate;
using DDD.Practice.Domain.SeedWork;
using DDD.Practice.Infrastructure.EntityConfigs;
using DDD.Practice.Infrastructure.Extensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Infrastructure
{
    public class SimpleDBContext : DbContext, IUnitOfWork
    {
        //DB SCHEMA 名稱
        public const string DEFAULT_SCHEMA = "simple";

        private readonly IMediator _mediator;
        private readonly ILogger<SimpleDBContext> _logger;

        // 建構式
        public SimpleDBContext(DbContextOptions<DbContext> options) : base(options) { }

        // DI
        public SimpleDBContext(DbContextOptions<DbContext> options, IMediator mediator, ILogger<SimpleDBContext> logger)
        {
            _logger = logger;
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }

        // DbSet
        public DbSet<MessageEntity> Messages { get; set; }

        // Fluent API
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new MessageEntityConfig());
        }

        // 實作 IUnitOfWork
        public async Task<bool> SaveEntityAsync(CancellationToken cancellationToken = default)
        {
            try
            {
                await _mediator.DispatchDomainEventsAsync(this); // Infrastructure.Extensions
                return await base.SaveChangesAsync(cancellationToken) > 0;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex.ToString());
                throw;
            }
        }
    }
}
