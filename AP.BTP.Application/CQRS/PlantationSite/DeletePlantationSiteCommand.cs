using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    public class DeletePlantationSiteCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class DeletePlantationSiteCommandValidator: AbstractValidator<DeletePlantationSiteCommand>
    {
        public DeletePlantationSiteCommandValidator(IUnitOfWork uow)
        {
        }
    }

    public class DeletePlantationSiteCommandHandler: IRequestHandler<DeletePlantationSiteCommand>
    {
        private readonly IUnitOfWork uow;

        public DeletePlantationSiteCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }
        
        public async Task Handle(DeletePlantationSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(request.Id);

            if(plantationSite != null)
            { 
                Console.WriteLine("Deleting plantation site");

                foreach (Domain.Zone zone in plantationSite.Zones)
                {
                    Console.WriteLine("Deleting plantation zones");
                    await uow.ZoneRepository.Delete(zone.Id);
                }
                
                uow.PlantationSiteRepository.Delete(plantationSite);     
            }

            await uow.Commit();
        }
    }
}
