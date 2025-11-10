using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    /// <summary>
    /// Represents a query to retrieve a single plantation site by its unique identifier.
    /// </summary>
    public class GetPlantationSiteByIdQuery: IRequest<PlantationSiteDTO>
    {
        /// <summary>
        /// The unique identifier of the plantation site to retrieve.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetPlantationSiteByIdQuery"/>.
    /// </summary>
    public class GetPlantationSiteByIdQueryValidator: AbstractValidator<GetPlantationSiteByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPlantationSiteByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential data checks (currently unused).</param>
        public GetPlantationSiteByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetPlantationSiteByIdQuery"/> by retrieving the plantation site with the specified Id from the database.
    /// </summary>
    public class GetPlantationSiteByIdQueryHandler: IRequestHandler<GetPlantationSiteByIdQuery, PlantationSiteDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetPlantationSiteByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for accessing the plantation site repository.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetPlantationSiteByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetPlantationSiteByIdQuery"/> by retrieving the plantation site and mapping it to a DTO.
        /// </summary>
        /// <param name="request">The query containing the Id of the plantation site to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A <see cref="PlantationSiteDTO"/> representing the requested plantation site.</returns>
        public async Task<PlantationSiteDTO> Handle(GetPlantationSiteByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(id:request.Id);
            PlantationSiteDTO plantationSiteDTO = mapper.Map<PlantationSiteDTO>(plantationSite);

            return plantationSiteDTO;
        }
    }
}
