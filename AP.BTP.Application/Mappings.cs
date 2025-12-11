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
    /// <item><description><see cref="Tree"/> <-> <see cref="TreeDto"/> (bi-directional)</description></item>
    /// <item><description><see cref="PlantationSite"/> <-> <see cref="PlantationSiteDto"/> (bi-directional)</description></item>
    /// <item><description><see cref="Zone"/> <-> <see cref="ZoneDto"/> (bi-directional)</description></item>
    /// <item><description><see cref="User"/> <-> <see cref="UserDto"/> (bi-directional)</description></item>
    /// <item><description><see cref="TaskList"/> -> <see cref="TaskListDto"/> (bi-directional)</description></item>
    /// <item><description><see cref="TaskItem"/> -> <see cref="TaskItemDto"/> (bi-directional)</description></item>
    /// <item><description><see cref="RegisterUserDto"/> -> <see cref="User"/></description></item>
    /// </list>
    /// </remarks>
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<Tree, TreeDto>().ReverseMap();
            CreateMap<PlantationSite, PlantationSiteDto>().ReverseMap();
            CreateMap<Zone, ZoneDto>().ReverseMap();
            CreateMap<User, UserDto>().ReverseMap();
            CreateMap<TreePicture, TreePictureDto>().ReverseMap();
            CreateMap<TaskList, TaskListDto>().ReverseMap();
            CreateMap<TaskItem, TaskItemDto>().ReverseMap();
            CreateMap<RegisterUserDto, User>();
        }
    }
}
