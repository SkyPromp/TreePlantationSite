using AP.BTP.Application.CQRS;
using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface ITreeRepository: IGenericRepository<Tree>
    {
        public Task Delete(int id);
        public Task HardDelete(int id);
        public Task HardDelete(Tree item);
        public Task<Paged<Tree>> GetAll(int pageNr, int pageSize, string? search);
    }
}
