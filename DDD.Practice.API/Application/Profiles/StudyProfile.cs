using AutoMapper;
using DDD.Practice.API.Application.Models;
using DDD.Practice.API.ViewModel;

namespace DDD.Practice.API.Application.Profiles
{
    public class StudyProfile : Profile
    {
        public StudyProfile()
        {
            /*建立合併模型*/
            CreateMap<MessageModel, MessageVo>()
                .ForMember(d => d.TypeTwo, opt => opt.Ignore()); // 忽略TypeTwo 參樹的合併
        }
    }
}
