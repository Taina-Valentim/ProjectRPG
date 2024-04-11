using ProjectRPG.DataAccess.Data;
using ProjectRPG.DataAccess.Repository.IRepository;

namespace ProjectRPG.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private RPGDbContext _db;
        public IArmaRepository Arma { get; private set; }
        public IAtributoRepository Atributo { get; private set; }
        public ICondicaoRepository Condicao { get; private set; }
        public IEquipamentoRepository Equipamento { get; private set; }
        public IItemRepository Item { get; private set; }
        public IPersonagemRepository Personagem { get; private set; }
        public IRPGUserRepository RPGUser {  get; private set; }


        public UnitOfWork(RPGDbContext db)
        {
            _db = db;
            Arma = new ArmaRepository(_db);
            Atributo = new AtributoRepository(_db);
            Condicao = new CondicaoRepository(_db);
            Equipamento = new EquipamentoRepository(_db);
            Item = new ItemRepository(_db);
            Personagem = new PersonagemRepository(_db);
            RPGUser = new RPGUserRepository(_db);
        }

        public void Salvar()
        {
            _db.SaveChanges();
        }
    }
}
