using DDD.Practice.Domain.Aggregates.MessageAggregate;
using MediatR;

namespace DDD.Practice.API.Application.Commands.Message
{
    public class AddMessageCommand : BaseCommand, IRequest<bool>
    { 
        public OneType TypeOne { get; set; }
        public int TypeTwo { get; set; }
        public string Content { get; set; }
    }
}
