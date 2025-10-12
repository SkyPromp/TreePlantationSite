using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;

namespace AP.BTP.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext ctxt;
        private readonly IMessageRepository messageRepo;

        public UnitOfWork(BTPContext ctxt, IMessageRepository messageRepo)
        {
            this.ctxt = ctxt;
            this.messageRepo = messageRepo;
        }
        
        public IMessageRepository MessageRepository => messageRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
