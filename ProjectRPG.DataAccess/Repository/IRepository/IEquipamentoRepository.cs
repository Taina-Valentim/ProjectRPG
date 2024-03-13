using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IEquipamentoRepository : IRepository<Equipamento>
    {
        void Alterar(Equipamento equipamento);
    }
}
