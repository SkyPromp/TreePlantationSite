using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.TaskItem;
using AP.BTP.Application.CQRS.TaskList;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Application.CQRS.User;
using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Domain;
using AutoMapper;

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
