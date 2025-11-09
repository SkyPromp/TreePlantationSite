using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface IUserRepository: IGenericRepository<User>
    {
        public Task<User?> GetUserByAuth0Id(string Auth0Id);
        Task<(IEnumerable<User> Items, int TotalCount)> GetAllPaged(int pageNr, int pageSize, string search);

        public Task Delete(int id);

    }
}
