using AP.BTP.Application.CQRS.PlantationSite;
using AP.BTP.Application.CQRS.Tree;
using AP.BTP.Domain;
using AutoMapper;

namespace AP.BTP.Application
{
    internal class Mappings : Profile
    {
        public Mappings()
        {
            CreateMap<PlantationSite, PlantationSiteDTO>().ReverseMap();
            CreateMap<Tree, TreeDTO>().ReverseMap();
        }
    }
}
