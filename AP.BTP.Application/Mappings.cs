using AP.BTP.Application.CQRS.Message;
using AP.BTP.Domain;
using AutoMapper;

namespace AP.BTP.Application
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Message, MessageDTO>().ReverseMap();
        }
    }
}
