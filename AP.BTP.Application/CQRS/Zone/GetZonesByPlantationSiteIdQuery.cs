using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a query to retrieve all zones associated with a specific plantation site.
    /// </summary>
    public class GetAllZonesByPlantationSiteIdQuery: IRequest<IEnumerable<ZoneDto>>
    {
        /// <summary>
        /// The unique identifier of the plantation site whose zones should be retrieved.
        /// </summary>
        public int PlantationSiteId { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetAllZonesByPlantationSiteIdQuery"/>.
    /// Currently no specific validation rules are applied, but the class is available for future use.
    /// </summary>
    public class GetAllZonesQueryValidator: AbstractValidator<GetAllZonesByPlantationSiteIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllZonesQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetAllZonesQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetAllZonesByPlantationSiteIdQuery"/> by retrieving all zones associated
    /// with the specified plantation site and returning them as <see cref="ZoneDto"/> instances.
    /// </summary>
    public class GetAllZonesQueryHandler: IRequestHandler<GetAllZonesByPlantationSiteIdQuery, IEnumerable<ZoneDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllZonesQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllZonesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the query by retrieving all zones for the given plantation site from the repository
        /// and mapping them to <see cref="ZoneDto"/> instances.
        /// </summary>
        /// <param name="request">The query containing the plantation site Id.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A collection of <see cref="ZoneDto"/> representing all zones for the specified plantation site.</returns>
        public async Task<IEnumerable<ZoneDto>> Handle(GetAllZonesByPlantationSiteIdQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Zone> zones = await uow.ZoneRepository.GetAllByPlantationSiteId(request.PlantationSiteId);

            IEnumerable<ZoneDto> zoneDTOs = mapper.Map<IEnumerable<ZoneDto>>(zones);

            return zoneDTOs;
        }
    }
}
