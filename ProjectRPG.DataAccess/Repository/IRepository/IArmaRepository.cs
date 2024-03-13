using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IArmaRepository : IRepository<Armamento>
    {
        void Alterar(Armamento arma);
    }
}
