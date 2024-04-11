using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IRPGUserRepository : IRepository<RPGUser>
    {
        void Alterar(RPGUser usuario);
    }
}
