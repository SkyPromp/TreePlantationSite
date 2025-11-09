using AP.BTP.Application.CQRS.Zone;
using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.CQRS.User
{
    public class GetUserByIdQuery : IRequest<UserDTO>
    {
        public int Id { get; set; }
    }

    public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
    {
        public GetUserByIdQueryValidator(IUnitOfWork uow)
        {
        }
    }

    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public GetUserByIdQueryHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }

        public async Task<UserDTO> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            Domain.User? user = await uow.UserRepository.GetById(id: request.Id);
            UserDTO userDTO = mapper.Map<UserDTO>(user);

            return userDTO;
        }
    }
}