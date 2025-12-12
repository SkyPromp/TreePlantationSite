using AP.BTP.Domain;

namespace AP.BTP.Application.Interfaces
{
    public interface ITreePictureRepository : IGenericRepository<TreePicture>
    {
        Task<ICollection<TreePicture>> GetAllByTreeId(int treeId);
    }
}