using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.TreePicture
{
    public class GetAllTreePicturesByTreeIdQuery : IRequest<List<TreePictureDTO>>
    {
        public int TreeId { get; set; }
    }

    public class GetAllTreePicturesByTreeIdQueryValidator : AbstractValidator<GetAllTreePicturesByTreeIdQuery>
    {
    }

    public class GetAllTreePicturesByTreeIdQueryHandler : IRequestHandler<GetAllTreePicturesByTreeIdQuery, List<TreePictureDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllTreePicturesByTreeIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<List<TreePictureDTO>> Handle(GetAllTreePicturesByTreeIdQuery request, CancellationToken cancellationToken)
        {
            ICollection<Domain.TreePicture> treePictures = await uow.TreePictureRepository.GetAllByTreeId(request.TreeId);

            return mapper.Map<List<TreePictureDTO>>(treePictures);
        }
    }
}