using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using ValdoBase.Domain.DomainObjects.Base.BaseErrors;

namespace ValdoBase.Domain.DomainObjects.Base
{
    public abstract class BaseEntity : BaseError
    {
        protected BaseEntity(Guid id)
        {
            SetId(id);
        }

        protected BaseEntity()
        {
        }

        [Key]
        public Guid Id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public long Indice { get; set; }

        private void SetId(Guid id)
        {
            if (id == Guid.Empty)
            {
                AddError($"Não é possível inserir no Id o valor: {id}");
            }
            else
            {
                Id = id;
            }
        }
    }
}