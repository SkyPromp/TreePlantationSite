using AP.BTP.Application.Interfaces;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.Message
{
    public class GetAllMessagesQuery: IRequest<IEnumerable<MessageDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
    }

    public class GetAllMessagesQueryHandler: IRequestHandler<GetAllMessagesQuery, IEnumerable<MessageDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetAllMessagesQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<IEnumerable<MessageDTO>> Handle(GetAllMessagesQuery request, CancellationToken cancellationToken)
        {
            return mapper.Map<IEnumerable<MessageDTO>>(await uow.MessageRepository.GetAll(request.PageNr, request.PageSize));
        }
    }
}
