using AP.BTP.Domain;
using AutoMapper;
using AP.BTP.Contracts.DTOs;

namespace AP.BTP.Application
{
    /// <summary>
    /// AutoMapper profile defining mappings between domain entities and their corresponding DTOs.
    /// </summary>
    /// <remarks>
    /// This profile sets up the following mappings:
    /// <list type="bullet">
    /// <item><description><see cref="Tree"/> <-> <see cref="TreeDTO"/> (bi-directional)</description></item>
    /// <item><description><see cref="PlantationSite"/> <-> <see cref="PlantationSiteDTO"/> (bi-directional)</description></item>
    /// <item><description><see cref="Zone"/> <-> <see cref="ZoneDTO"/> (bi-directional)</description></item>
    /// <item><description><see cref="User"/> <-> <see cref="UserDTO"/> (bi-directional)</description></item>
    /// <item><description><see cref="TaskList"/> -> <see cref="TaskListDTO"/></description></item>
    /// <item><description><see cref="TaskItem"/> -> <see cref="TaskItemDTO"/> (bi-directional)</description></item>
    /// </list>
    /// </remarks>
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Tree, TreeDTO>().ReverseMap();
            CreateMap<PlantationSite, PlantationSiteDTO>().ReverseMap();
            CreateMap<Zone, ZoneDTO>().ReverseMap();
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<TaskList, TaskListDTO>().ReverseMap();
            CreateMap<TaskItem, TaskItemDTO>().ReverseMap();
        }
    }
}
