using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class ItemRepository : Repository<Item>, IItemRepository
    {
        private readonly RPGDbContext _db;

        public ItemRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(Item item)
        {
            _db.Itens.Update(item);
        }
    }
}
