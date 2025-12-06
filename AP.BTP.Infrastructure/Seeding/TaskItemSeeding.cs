using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    /// <summary>
    /// Provides extension methods to seed <see cref="TaskItem"/> entities into the database.
    /// </summary>
    public static class TaskItemSeeding
    {
        /// <summary>
        /// Seeds the <see cref="TaskItem"/> entity with some sample records.
        /// </summary>
        /// <param name="modelBuilder">The <see cref="EntityTypeBuilder{TEntity}"/> used to configure the entity.</param>
        /// <remarks>
        /// Each seeded <see cref="TaskItem"/> will have:
        /// <list type="bullet">
        /// </list>
        /// This method uses <see cref="HasData(IEnumerable{T})"/> to insert the data when migrating or creating the database.
        /// </remarks>
        public static void Seed(this EntityTypeBuilder<TaskItem> modelBuilder)
        {
            Random random = new Random(1);
            List<TaskItem> taskItems = new List<TaskItem>();
            int totalTaskItems = 0;

            string[] descriptions =
            {
                "Snoei dode of overgroeide takken om de boom gezond te houden.",
                "Breng organische mest rond de basis van de boom aan.",
                "Controleer bomen op ziektes of plagen.",
                "Geef water aan pas geplante bomen om de groei te ondersteunen.",
                "Breng mulch aan rond de boom om vocht vast te houden en onkruid te voorkomen.",
                "Controleer en herstel boomsteunen of palen indien nodig.",
                "Verwijder invasieve planten of onkruid bij de wortels van de boom.",
                "Monitor de bodemkwaliteit en pH rondom de bomen.",
                "Oogst vruchten of zaden van volwassen bomen.",
                "Voer een veiligheidscontrole uit en verwijder gevaarlijke takken."
            };

            string[] titles =
            {
                "Snoeien van takken",
                "Bemesten van bomen",
                "Controle op ziektes en plagen",
                "Water geven aan jonge bomen",
                "Mulchen rondom bomen",
                "Controle van boomsteunen",
                "Onkruid verwijderen bij wortels",
                "Bodemkwaliteit monitoren",
                "Oogsten van vruchten of zaden",
                "Veiligheidstakcontrole"
            };

            for (int userIdOffset = 0; userIdOffset < 3; userIdOffset++)
            {
                for (int taskListId = 1; taskListId <= 101; taskListId++)
                {
                    int taskItemCount = random.Next(1, 5);
                    int descriptionOffset = random.Next(0, descriptions.Length);

                    for (int i = 0; i < taskItemCount; i++)
                    {
                        taskItems.Add(new TaskItem()
                        {
                            Id = ++totalTaskItems,
                            Title = titles[(i + descriptionOffset) % titles.Length],
                            TaskListId = userIdOffset * 101 + taskListId,
                            Description = descriptions[(i + descriptionOffset) % descriptions.Length],
                            DurationInMinutes = random.Next(Math.Min(30, 8 * 60 / taskItemCount - 1), 8 * 60 / taskItemCount - 1)
                        });
                    }
                }
            }

            modelBuilder.HasData(taskItems);
        }
    }
}
