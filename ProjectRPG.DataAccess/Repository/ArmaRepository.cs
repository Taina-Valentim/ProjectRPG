using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class ArmaRepository : Repository<Arma>, IArmaRepository
    {
        private readonly RPGDbContext _db;

        public ArmaRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(Arma arma)
        {
            _db.Armas.Update(arma);
        }
    }
}
