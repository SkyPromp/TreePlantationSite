using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface ITreeRepository: IGenericRepository<Tree>
    {
        public Task<int> GetTotalPages(int pageSize);
        public void Delete(int id);
    }
}
