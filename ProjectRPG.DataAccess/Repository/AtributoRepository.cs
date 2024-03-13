using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class AtributoRepository : Repository<Atributo>, IAtributoRepository
    {
        private readonly RPGDbContext _db;

        public AtributoRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(Atributo atributo)
        {
            _db.Atributos.Update(atributo);
        }
    }
}
