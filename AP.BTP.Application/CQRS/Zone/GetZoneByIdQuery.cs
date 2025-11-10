using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Zone
{
    /// <summary>
    /// Represents a query to retrieve a zone by its unique identifier.
    /// </summary>
    public class GetZoneByIdQuery: IRequest<ZoneDTO>
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
    /// and returning it as a <see cref="ZoneDTO"/>.
    /// </summary>
    public class GetZoneByIdQueryHandler: IRequestHandler<GetZoneByIdQuery, ZoneDTO>
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
        /// and returning it as a <see cref="ZoneDTO"/>.
        /// </summary>
        /// <param name="request">The query containing the Id of the zone to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The zone mapped as a <see cref="ZoneDTO"/>.</returns>
        public async Task<ZoneDTO> Handle(GetZoneByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Zone? zone = await uow.ZoneRepository.GetById(id:request.Id);
            ZoneDTO zoneDTO = mapper.Map<ZoneDTO>(zone);

            return zoneDTO;
        }
    }
}
