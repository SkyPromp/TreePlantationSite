using AP.BTP.Application.Interfaces;
using AP.BTP.Contracts.DTOs;
using AutoMapper;
using MediatR;

namespace AP.BTP.Application.CQRS.User
{
    public class GetAllOperatorsPagedQuery : IRequest<PagedResponseDTO<UserDTO>>
    {
        public int PageNr { get; set; }
        public int PageSize { get; set; }
        public required string Search { get; set; }
    }

    public class GetAllOperatorsPagedQueryHandler : IRequestHandler<GetAllOperatorsPagedQuery, PagedResponseDTO<UserDTO>>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;
        private readonly IAuth0ManagementService auth0;

        public GetAllOperatorsPagedQueryHandler(IUnitOfWork uow, IMapper mapper, IAuth0ManagementService auth0)
        {
            this.uow = uow;
            this.mapper = mapper;
            this.auth0 = auth0;
        }

        public async Task<PagedResponseDTO<UserDTO>> Handle(GetAllOperatorsPagedQuery request, CancellationToken cancellationToken)
        {
            (IEnumerable<Domain.User> items, int totalCount) = await uow.UserRepository.GetAllOperatorsPaged(request.PageNr, request.PageSize, request.Search);

            IEnumerable<UserDTO> users = mapper.Map<IEnumerable<UserDTO>>(items);

            foreach (UserDTO user in users)
            {
                Auth0UserDTO? auth0user = await auth0.GetUserByIdAsync(user.Auth0Id);
                user.Name = auth0user?.username ?? string.Empty;
                user.Email = auth0user?.email ?? string.Empty;
            }
            return new PagedResponseDTO<UserDTO>
            {
                Items = users,
                PageNumber = request.PageNr,
                PageSize = request.PageSize,
                TotalItems = totalCount
            };
        }
    }
}
