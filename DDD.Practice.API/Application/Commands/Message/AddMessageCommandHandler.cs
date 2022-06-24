using DDD.Practice.Domain.Aggregates.MessageAggregate;
using MediatR;

namespace DDD.Practice.API.Application.Commands.Message
{
    public class AddMessageCommandHandler : IRequestHandler<AddMessageCommand, bool>
    {
        private readonly ILogger<AddMessageCommandHandler> _logger;
        private readonly IMessageRepository _messageRepo;

        public AddMessageCommandHandler(ILogger<AddMessageCommandHandler> logger, IMessageRepository messageRepo)
        {
            _logger = logger;
            _messageRepo = messageRepo;
        }

        public async Task<bool> Handle(AddMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                MessageEntity AddData = new(request.TypeOne, request.TypeTwo, request.Content);
                _messageRepo.Add(AddData);
                if (!await _messageRepo.UnitOfWork.SaveEntityAsync(cancellationToken))
                    return false;
                return true;
            }
            catch(Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
