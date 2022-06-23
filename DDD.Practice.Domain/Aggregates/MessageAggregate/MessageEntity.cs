using DDD.Practice.Domain.SeedWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DDD.Practice.Domain.Aggregates.MessageAggregate
{
    public class MessageEntity : Entity, IAggregateRoot
    {
        // 定義資料
        public OneType TypeEnum { get; private set; }
        public TwoType TypeTwo { get; private set; }
        public string Content { get; private set; }
        public DateTime CreateTime { get; private set; }

        // 資料修改方法
        public MessageEntity(OneType typeOne, int typeTwo, string content)
        {
            TypeEnum = typeOne;
            TypeTwo = TwoType.From(typeTwo);
            Content = content;
            CreateTime = DateTime.Now;
        }
        public void UpdateMessage(OneType typeOne, int typeTwo, string content)
        {
            TypeEnum = typeOne;
            TypeTwo = TwoType.From(typeTwo);
            Content = content;
        }
    }
}
