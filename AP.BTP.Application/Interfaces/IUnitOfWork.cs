namespace AP.BTP.Application.Interfaces
{
    public interface IUnitOfWork
    {
        Task Commit();
        IMessageRepository MessageRepository { get; }
    }
}