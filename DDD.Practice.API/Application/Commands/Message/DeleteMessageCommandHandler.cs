using DDD.Practice.Domain.Aggregates.MessageAggregate;
using MediatR;

namespace DDD.Practice.API.Application.Commands.Message
{
    public class DeleteMessageCommandHandler : IRequestHandler<DeleteMessageCommand, bool>
    {
        private readonly ILogger<DeleteMessageCommandHandler> _logger;
        private readonly IMessageRepository _messageRepo;

        public DeleteMessageCommandHandler(ILogger<DeleteMessageCommandHandler> logger, IMessageRepository messageRepo)
        {
            _logger = logger;
            _messageRepo = messageRepo;
        }
        public async Task<bool> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
        {
            try
            {
                MessageEntity getData = await _messageRepo.GetAsync(request.Id, cancellationToken);
                if (getData == null)
                    return false;
                _messageRepo.Delete(getData);
                if (!await _messageRepo.UnitOfWork.SaveEntityAsync(cancellationToken))
                    return false;
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, ex.Message);
                return false;
            }
        }
    }
}
