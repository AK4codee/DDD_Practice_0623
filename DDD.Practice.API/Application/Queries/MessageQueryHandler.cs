using AutoMapper;
using Dapper;
using DDD.Practice.API.Application.Models;
using DDD.Practice.API.ViewModel;
using DDD.Practice.Infrastructure.SeedWork;
using MediatR;


namespace DDD.Practice.API.Application.Queries
{
    public class MessageQueryHandler : IRequestHandler<MessageQuery, List<MessageVo>>
    {
        private readonly ILogger<MessageQueryHandler> _logger;
        private readonly IUnitOfDapper _dapper;
        private readonly IMapper _mapper;
        public MessageQueryHandler(ILogger<MessageQueryHandler> logger, IUnitOfDapper dapper, IMapper mapper)
        {
            _logger = logger;
            _dapper = dapper;
            _mapper = mapper;
        }
        public async Task<List<MessageVo>> Handle(MessageQuery request, CancellationToken cancellationToken)
        {
            List<MessageVo> result = new();
            List<MessageModel> getData = new();
            DynamicParameters parameters = new();

            parameters.Add("@TypeOne", request.TypeOne);
            string sqlQuery = @"SELECT * FROM messages WHERE type_one=@TypeOne;";

            var multi = await _dapper.Slave.QueryMultipleAsync(new CommandDefinition(sqlQuery, parameters, cancellationToken: cancellationToken));
            if (multi == null)
                return result;
            getData = multi.Read<MessageModel>().ToList();
            result = _mapper.Map<List<MessageVo>>(getData); // DB資料合併到ViewModel可針對資料做格式化
            return result;
        }
    }
}
