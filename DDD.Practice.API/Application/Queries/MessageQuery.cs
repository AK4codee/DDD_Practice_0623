using DDD.Practice.API.ViewModel;
using MediatR;

namespace DDD.Practice.API.Application.Queries
{
    public class MessageQuery : IRequest<List<MessageVo>>
    {
        public int TypeOne { get; set; }
    }
}
