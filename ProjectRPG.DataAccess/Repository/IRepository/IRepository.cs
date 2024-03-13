using System.Linq.Expressions;

namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> BuscarTodos();
        T? Buscar(Expression<Func<T, bool>> filtro);
        void Adicionar(T entidade);
        void Excluir(T entidade);
        void ExcluirVarios(IEnumerable<T> entidades);

    }
}
