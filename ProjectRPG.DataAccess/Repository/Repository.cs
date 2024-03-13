using Microsoft.EntityFrameworkCore;
using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;
using System.Linq.Expressions;

namespace ProjectRPG.DataAccess.Repository
{
    public class Repository<T> : IRepository<T> where T : class
    {
        internal DbSet<T> DbSet { get; set; }
        private readonly RPGDbContext _db;
        public Repository(RPGDbContext db)
        {
            _db = db;
            this.DbSet = _db.Set<T>();
        }

        public void Adicionar(T entidade)
        {
            DbSet.Add(entidade);
        }

        public T? Buscar(Expression<Func<T, bool>> filtro)
        {
            return DbSet.FirstOrDefault(filtro);
        }

        public IEnumerable<T> BuscarTodos()
        {
            return DbSet.ToList();
        }

        public void Excluir(T entidade)
        {
            DbSet.Remove(entidade);
        }

        public void ExcluirVarios(IEnumerable<T> entidades)
        {
            DbSet.RemoveRange(entidades);
        }
    }
}
