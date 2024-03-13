using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IPersonagemRepository : IRepository<Personagem>
    {
        void Alterar(Personagem personagem);
    }
}
