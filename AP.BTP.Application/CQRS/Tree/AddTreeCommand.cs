using AP.BTP.Application.Interfaces;
using AutoMapper;
using FluentValidation;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AP.BTP.Application.CQRS.Tree
{
    public class AddTreeCommand: IRequest<TreeDTO>
    {
        public TreeDTO Tree { get; set; }
    }

    public class AddTreeValidator: AbstractValidator<AddTreeCommand>
    {
        public AddTreeValidator(IUnitOfWork uow)
        {
        }
    }

    public class AddTreeCommandHandler: IRequestHandler<AddTreeCommand, TreeDTO>
    {
        private readonly IUnitOfWork uow;
        private readonly IMapper mapper;

        public AddTreeCommandHandler(IUnitOfWork uow, IMapper mapper)
        {
            this.uow = uow;
            this.mapper = mapper;
        }
        
        public async Task<TreeDTO> Handle(AddTreeCommand request, CancellationToken cancellationToken)
        {
            Domain.Tree tree = mapper.Map<Domain.Tree>(request.Tree);

            await uow.TreeRepository.Create(tree);
            await uow.Commit();

            return request.Tree;
        }
    }
}
