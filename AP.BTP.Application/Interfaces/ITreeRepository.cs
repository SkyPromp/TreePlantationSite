using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface ITreeRepository: IGenericRepository<Tree>
    {
        public Task<int> GetTotalPages(int pageSize);
        public Task Delete(int id);
        public Task HardDelete(int id);
        public Task HardDelete(Tree item);
        public Task<IEnumerable<Tree>> GetAll(int pageNr, int pageSize);
    }
}
