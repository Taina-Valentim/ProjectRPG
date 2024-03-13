using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository
{
    public class EquipamentoRepository : Repository<Equipamento>, IEquipamentoRepository
    {
        private readonly RPGDbContext _db;

        public EquipamentoRepository(RPGDbContext db) : base(db)
        {
            _db = db;
        }
        public void Alterar(Equipamento equipamento)
        {
            _db.Equipamentos.Update(equipamento);
        }
    }
}
