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
    public class GetAllTreeQuery: IRequest<IEnumerable<TreeDTO>>  // TODO this should probably be merged in with GetTreeQuery
    {
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
    public class GetAllTreeQueryHandler: IRequestHandler<GetAllTreeQuery, IEnumerable<TreeDTO>>
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
        /// Handles the <see cref="GetAllTreeQuery"/> by fetching all trees from the repository and mapping them to <see cref="TreeDTO"/>.
        /// </summary>
        /// <param name="request">The query request (no parameters required).</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A collection of <see cref="TreeDTO"/> objects representing all trees in the system.</returns>
        public async Task<IEnumerable<TreeDTO>> Handle(GetAllTreeQuery request, CancellationToken cancellationToken)
        {
            IEnumerable<Domain.Tree> trees = await uow.TreeRepository.GetAll();
            IEnumerable<TreeDTO> treeDTOs = mapper.Map<IEnumerable<TreeDTO>>(trees);

            return treeDTOs;
        }
    }
}
