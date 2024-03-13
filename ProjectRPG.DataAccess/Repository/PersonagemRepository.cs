using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class PersonagemRepository : Repository<Personagem>, IPersonagemRepository
    {
        private readonly RPGDbContext _db;

        public PersonagemRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(Personagem personagem)
        {
            _db.Personagens.Update(personagem);
        }
    }
}
