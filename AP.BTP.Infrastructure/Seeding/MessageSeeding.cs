using AP.BTP.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AP.BTP.Infrastructure.Seeding
{
    public static class MessageSeeding
    {
        public static void Seed(this EntityTypeBuilder<Message> modelBuilder)
        {
            modelBuilder.HasData([
                new Message()
                {
                    Id = -1,
                    Content = "Banana"
                },

                new Message()
                {
                    Id = -2,
                    Content = "Works"
                },
            ]);
        }
    }
}
