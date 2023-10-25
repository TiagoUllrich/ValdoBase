namespace ValdoBase.Domain.DomainObjects
{
    public interface IEntity
    {
        DateTime DataDeCriacao { get; }
        DateTime? DataDeExclusao { get; }
        bool Excluido { get; }
        Guid Id { get; }
        long Indice { get; }

        void SetDataDeExclusao(DateTime? dataDeExclusao);

        void SetExcluido(bool excluido);
    }
}