using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IArmaRepository : IRepository<Arma>
    {
        void Alterar(Arma arma);
    }
}
