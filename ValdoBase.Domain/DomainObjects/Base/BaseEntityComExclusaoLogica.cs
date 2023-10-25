namespace ValdoBase.Domain.DomainObjects.Base
{
    public class BaseEntityComExclusaoLogica : BaseEntity
    {
        public BaseEntityComExclusaoLogica(Guid id, DateTime? dataDeExclusao, bool excluido)
            : base(id)
        {
            SetDataDeExclusao(dataDeExclusao);
            SetExcluido(excluido);
        }

        public BaseEntityComExclusaoLogica()
        {
        }

        public DateTime? DataDeExclusao { get; private set; }

        public bool Excluido { get; private set; }

        public virtual void SetDataDeExclusao(DateTime? dataDeExclusao)
        {
            if (dataDeExclusao.HasValue)
            {
                SetExcluido(excluido: true);
            }

            DataDeExclusao = dataDeExclusao;
        }

        public virtual void SetExcluido(bool excluido)
        {
            if (!excluido)
            {
                SetDataDeExclusao(null);
            }

            Excluido = excluido;
        }
    }
}