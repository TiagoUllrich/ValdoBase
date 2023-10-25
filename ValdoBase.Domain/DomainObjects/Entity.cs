using ValdoBase.Domain.DomainObjects.Base;

namespace ValdoBase.Domain.DomainObjects
{
    public class Entity : BaseEntityComExclusaoLogica, IEntity
    {
        protected Entity() : base(Guid.NewGuid(), null, false)
        {
            DataDeCriacao = DateTime.SpecifyKind(DateTime.UtcNow, DateTimeKind.Unspecified);
        }

        public DateTime DataDeCriacao { get; private set; }

        public static bool operator !=(Entity a, Entity b)
        {
            return !(a == b);
        }

        public static bool operator ==(Entity a, Entity b)
        {
            if (a is null && b is null)
                return true;

            if (a is null || b is null)
                return false;

            return a.Equals(b);
        }

        public override bool Equals(object obj)
        {
            var compareTo = obj as Entity;

            if (ReferenceEquals(this, compareTo)) return true;
            if (compareTo is null) return false;

            return Id.Equals(compareTo.Id);
        }

        public override int GetHashCode()
        {
            return (GetType().GetHashCode() * 907) + Id.GetHashCode();
        }

        public override string ToString()
        {
            return GetType().Name + " [Id=" + Id + "]";
        }
    }
}