namespace DDD.Practice.API.Application.Models
{
    public class MessageModel
    {
        public int id { get; set; }
        public int TypeOne { get; set; }
        public int TypeTwo { get; set; }
        public string Content { get; set; }
        public DateTime CreateTime { get; set; }
    }
}
