using ProjectRPG.Models;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IAtributoRepository : IRepository<Atributo>
    {
        void Alterar(Atributo atributo);
    }
}
