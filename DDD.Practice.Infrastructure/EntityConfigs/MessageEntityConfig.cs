using DDD.Practice.Domain.Aggregates.MessageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Practice.Infrastructure.EntityConfigs
{
    internal class MessageEntityConfig : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            throw new NotImplementedException();
        }
    }
}
