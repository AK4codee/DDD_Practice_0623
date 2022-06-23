using DDD.Practice.Domain.Aggregates.MessageAggregate;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DDD.Practice.Infrastructure.EntityConfigs
{
    internal class MessageEntityConfig : IEntityTypeConfiguration<MessageEntity>
    {
        public void Configure(EntityTypeBuilder<MessageEntity> builder)
        {
            builder.ToTable("message", SimpleDBContext.DEFAULT_SCHEMA);
            builder.HasKey(x => x.Id);
            builder.Ignore(x => x.DomainEvents);

            builder.Property(x => x.TypeEnum).HasColumnName("type_one");
            config.Property(t => t.TypeTwo).HasColumnName("type_two").HasConversion(new ValueConverter<TwoType, int>(from => from.Id, to => TwoType.From(to)));
            builder.Property(x => x.Content).HasColumnName("content").IsRequired(false);
            builder.Property(x => x.CreateTime).HasColumnName("create_time");
        }
    }
}
