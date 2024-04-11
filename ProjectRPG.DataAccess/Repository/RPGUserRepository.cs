using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class RPGUserRepository : Repository<RPGUser>, IRPGUserRepository
    {
        private readonly RPGDbContext _db;

        public RPGUserRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(RPGUser usuario)
        {
            _db.RPGUsers.Update(usuario);
        }
    }
}
