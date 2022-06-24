using MediatR;

namespace DDD.Practice.API.Application.Commands.Message
{
    public class DeleteMessageCommand : BaseCommand, IRequest<bool>
    {
        public int Id { get; set; }
    }
}
