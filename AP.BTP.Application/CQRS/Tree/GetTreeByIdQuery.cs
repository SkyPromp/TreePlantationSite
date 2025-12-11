using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.Tree
{
    /// <summary>
    /// Represents a query to retrieve a tree by its unique identifier.
    /// </summary>
    public class GetTreeByIdQuery: IRequest<TreeDto>
    {
        /// <summary>
        /// The unique identifier of the tree to retrieve.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetTreeByIdQuery"/>.
    /// Currently no specific validation rules are applied, but the class is available for future validation needs.
    /// </summary>
    public class GetTreeByIdQueryValidator: AbstractValidator<GetTreeByIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetTreeByIdQueryValidator"/> class.
        /// </summary>
        /// <param name="uow">The unit of work, available for potential validation logic.</param>
        public GetTreeByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="GetTreeByIdQuery"/> by retrieving the specified tree from the repository and mapping it to a DTO.
    /// </summary>
    public class GetTreeByIdQueryHandler: IRequestHandler<GetTreeByIdQuery, TreeDto>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetTreeByIdQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetTreeByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the <see cref="GetTreeByIdQuery"/> by fetching the tree with the specified Id from the repository and returning it as a <see cref="TreeDto"/>.
        /// </summary>
        /// <param name="request">The query containing the Id of the tree to retrieve.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>The <see cref="TreeDto"/> representing the requested tree.</returns>
        public async Task<TreeDto> Handle(GetTreeByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.Tree? tree = await uow.TreeRepository.GetById(id:request.Id);
            TreeDto treeDTO = mapper.Map<TreeDto>(tree);

            return treeDTO;
        }
    }
}
