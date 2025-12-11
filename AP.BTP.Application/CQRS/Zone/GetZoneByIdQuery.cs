using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a query to retrieve a zone by its unique identifier.
    /// </summary>
    public class GetZoneByIdQuery: IRequest<ZoneDto>
    {
        /// <summary>
        /// The unique identifier of the zone to retrieve.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetZoneByIdQuery"/>.
    /// Currently no specific validation rules are applied, but the class is available for future use.
    /// </summary>
    public class GetZoneByIdQueryValidator: AbstractValidator<GetZoneByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetZoneByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetZoneByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetZoneByIdQuery"/> by retrieving the specified zone from the repository
    /// and returning it as a <see cref="ZoneDto"/>.
    /// </summary>
    public class GetZoneByIdQueryHandler: IRequestHandler<GetZoneByIdQuery, ZoneDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetZoneByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetZoneByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the query by retrieving the zone with the specified Id from the database
        /// and returning it as a <see cref="ZoneDto"/>.
        /// </summary>
        /// <param name="request">The query containing the Id of the zone to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The zone mapped as a <see cref="ZoneDto"/>.</returns>
        public async Task<ZoneDto> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Zone? zone = await uow.ZoneRepository.GetById(id:request.Id);
            ZoneDto zoneDTO = mapper.Map<ZoneDto>(zone);

            return zoneDTO;
        }
    }
}
