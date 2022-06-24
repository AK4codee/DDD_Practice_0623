using DDD.Practice.Domain.Aggregates.MessageAggregate;
using MediatR;

namespace DDD.Practice.API.Application.Commands.Message
{
    public class UpdateMessageCommand : BaseCommand, IRequest<bool>
    {
        public int Id { get; set; }
        public OneType TypeOne { get; set; }
        public int TypeTwo { get; set; }
        public string Content { get; set; }
    }
}
