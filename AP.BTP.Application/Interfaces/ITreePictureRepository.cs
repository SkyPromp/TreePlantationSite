using AP.BTP.Application.Interfaces;
using AP.BTP.Domain;

public interface ITreePictureRepository : IGenericRepository<TreePicture>
{
    Task<ICollection<TreePicture>> GetAllByTreeId(int treeId);
}