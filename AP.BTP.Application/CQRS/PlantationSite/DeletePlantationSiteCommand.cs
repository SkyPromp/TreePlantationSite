using AP.BTP.Application.Interfaces;
using FluentValidation;
using MediatR;

namespace AP.BTP.Application.CQRS.PlantationSite
{
    /// <summary>
    /// Represents a command to delete a plantation site and its associated zones from the system.
    /// </summary>
    public class DeletePlantationSiteCommand: IRequest
    {
        /// <summary>
        /// The unique identifier of the plantation site to delete.
        /// </summary>
        public int Id { get; set; }
    }

    /// <summary>
    /// Provides validation rules for the <see cref="DeletePlantationSiteCommand"/>.
    /// </summary>
    public class DeletePlantationSiteCommandValidator : AbstractValidator<DeletePlantationSiteCommand>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePlantationSiteCommandValidator"/> class.
        /// Currently does not define validation rules, but serves as a placeholder for future logic.
        /// </summary>
        /// <param name="uow">The unit of work used for potential validation or lookup operations.</param>
        public DeletePlantationSiteCommandValidator(IUnitOfWork uow)
        {
        }
    }

    /// <summary>
    /// Handles the <see cref="DeletePlantationSiteCommand"/> by performing a soft delete 
    /// on the specified plantation site and all related zones.
    /// </summary>
    public class DeletePlantationSiteCommandHandler : IRequestHandler<DeletePlantationSiteCommand>
    {
        private readonly IUnitOfWork uow;

        /// <summary>
        /// Initializes a new instance of the <see cref="DeletePlantationSiteCommandHandler"/> class.
        /// </summary>
        /// <param name="uow">The unit of work used for database operations.</param>
        public DeletePlantationSiteCommandHandler(IUnitOfWork uow)
        {
            this.uow = uow;
        }

        /// <summary>
        /// Handles the <see cref="DeletePlantationSiteCommand"/> by deleting the specified plantation site 
        /// and all zones associated with it. Performs a logical (soft) delete by marking entities as deleted.
        /// </summary>
        /// <param name="request">The command containing the ID of the plantation site to delete.</param>
        /// <param name="cancellationToken">A token to monitor for cancellation requests.</param>
        public async Task Handle(DeletePlantationSiteCommand request, CancellationToken cancellationToken)
        {
            Domain.PlantationSite? plantationSite = await uow.PlantationSiteRepository.GetById(request.Id);

            if (plantationSite != null)
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
