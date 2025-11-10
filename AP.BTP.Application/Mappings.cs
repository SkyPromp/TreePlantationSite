using AP.BTP.Domain;
using AutoMapper;
using AP.BTP.Contracts.DTOs;

namespace AP.BTP.Application
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Tree, TreeDTO>().ReverseMap();
            CreateMap<PlantationSite, PlantationSiteDTO>().ReverseMap();
            CreateMap<Zone, ZoneDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<TaskList, TaskListDTO>();
            CreateMap<TaskItem, TaskItemDTO>();

        }
    }
}
