using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    /// <summary>
    /// Represents a query to retrieve all trees in the system.
    /// </summary>
    public class GetAllTreeQuery: IRequest<IEnumerable<TreeDto>>
    {
        /// <summary>
        /// An optional search string to filter trees by relevant fields (e.g., species name).
        /// </summary>
        public string? Search { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetAllTreeQuery"/>.
    /// Currently no specific validation rules are applied, but the class exists for future extensibility.
    /// </summary>
    public class GetAllTreeQueryValidator: AbstractValidator<GetAllTreeQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTreeQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetAllTreeQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetAllTreeQuery"/> by retrieving all trees from the repository and mapping them to DTOs.
    /// </summary>
    public class GetAllTreeQueryHandler: IRequestHandler<GetAllTreeQuery, IEnumerable<TreeDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTreeQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllTreeQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetAllTreeQuery"/> by fetching all trees from the repository and mapping them to <see cref="TreeDto"/>.
        /// </summary>
        /// <param name="request">The query request (no parameters required).</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A collection of <see cref="TreeDto"/> objects representing all trees in the system.</returns>
        public async Task<IEnumerable<TreeDto>> Handle(GetAllTreeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Tree> trees = await uow.TreeRepository.GetAll(request.Search);
            IEnumerable<TreeDto> treeDTOs = mapper.Map<IEnumerable<TreeDto>>(trees);

            return treeDTOs;
        }
    }
}
