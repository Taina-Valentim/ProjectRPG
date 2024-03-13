using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface ICondicaoRepository : IRepository<Condicao>
    {
        void Alterar(Condicao condicao);
    }
}
