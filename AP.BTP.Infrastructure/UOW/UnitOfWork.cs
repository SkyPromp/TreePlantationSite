using AP.BTP.Application.Interfaces;
using AP.BTP.Infrastructure.Context;

namespace AP.BTP.Infrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly BTPContext ctxt;
        private readonly ITreeRepository treeRepo;
        private readonly IMessageRepository messageRepo;

        public UnitOfWork(
            BTPContext ctxt,
            IMessageRepository messageRepo,
            ITreeRepository treeRepo
            )
        {
            this.ctxt = ctxt;
            this.messageRepo = messageRepo;
            this.treeRepo = treeRepo;
        }
        
        public IMessageRepository MessageRepository => messageRepo;
        public ITreeRepository TreeRepository => treeRepo;

        public async Task Commit()
        {
            await ctxt.SaveChangesAsync();
        }
    }
}
