using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IItemRepository : IRepository<Item>
    {
        void Alterar(Item item);
    }
}
