using BLL.DTOEntities;

namespace BLL.Interfaces
{
    public interface ITagService
    {
        void Create(TagDTO tagDto);
        void Remove(int id);
    }
}