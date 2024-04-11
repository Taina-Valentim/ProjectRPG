namespace ProjectRPG.DataAccess.Repository.IRepository
{
    public interface IUnitOfWork
    {
        public IArmaRepository Arma { get; }
        public IAtributoRepository Atributo { get; }
        public ICondicaoRepository Condicao { get; }
        public IEquipamentoRepository Equipamento { get; }
        public IItemRepository Item { get; }
        public IPersonagemRepository Personagem { get; }
        public IRPGUserRepository RPGUser { get; }

        void Salvar();
    }
}
