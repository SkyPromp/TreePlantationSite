using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    /// <summary>
    /// Represents a query to retrieve all tree pictures associated with a specific tree.
    /// </summary>
    public class GetAllTreePicturesByTreeIdQuery : IRequest<List<TreePictureDto>>
    {
        /// <summary>
        /// The ID of the tree for which to retrieve pictures.
        /// </summary>
        public int TreeId { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="GetAllTreePicturesByTreeIdQuery"/>.
    /// </summary>
    public class GetAllTreePicturesByTreeIdQueryValidator : AbstractValidator<GetAllTreePicturesByTreeIdQuery>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTreePicturesByTreeIdQueryValidator"/> class.
        /// </summary>
        public GetAllTreePicturesByTreeIdQueryValidator()
        {
            RuleFor(x => x.TreeId)
                .GreaterThan(0)
                .WithMessage("TreeId must be greater than zero.");
        }
    }

    /// <summary>
    /// Handles the <see cref="GetAllTreePicturesByTreeIdQuery"/> by retrieving all tree pictures from the repository.
    /// </summary>
    public class GetAllTreePicturesByTreeIdQueryHandler : IRequestHandler<GetAllTreePicturesByTreeIdQuery, List<TreePictureDto>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        /// <summary>
        /// Initializes a new instance of the <see cref="GetAllTreePicturesByTreeIdQueryHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for repository operations.</param>
        /// <param name="mapper">The mapper used to convert domain entities to DTOs.</param>
        public GetAllTreePicturesByTreeIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        /// <summary>
        /// Handles the query by retrieving all tree pictures associated with the specified tree ID.
        /// </summary>
        /// <param name="request">The query containing the tree ID.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        /// <returns>A list of <see cref="TreePictureDto"/> representing the tree's pictures.</returns>
        public async Task<List<TreePictureDto>> Handle(GetAllTreePicturesByTreeIdQuery request, CancellationToken cancellationToken)
        {
            ICollection<Domain.TreePicture> treePictures = await uow.TreePictureRepository.GetAllByTreeId(request.TreeId);

            return mapper.Map<List<TreePictureDto>>(treePictures);
        }
    }
}