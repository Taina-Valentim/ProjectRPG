using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class CondicaoRepository : Repository<Condicao>, ICondicaoRepository
    {
        private readonly RPGDbContext _db;

        public CondicaoRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(Condicao condicao)
        {
            _db.Condicoes.Update(condicao);
        }
    }
}
