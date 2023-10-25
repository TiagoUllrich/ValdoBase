using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValdoBase.Domain.DomainObjects;

namespace ValdoBase.Database.Configs
{
    public abstract class BaseEntityConfig<TEntity> : IEntityTypeConfiguration<TEntity>
        where TEntity : class, IEntity
    {
        public void Configure(EntityTypeBuilder<TEntity> builder)
        {
            builder.ToTable(typeof(TEntity).Name);
            builder.HasKey(x => x.Id);

            builder.Property(x => x.DataDeCriacao);
            builder.Property(x => x.DataDeExclusao);

            builder.HasIndex(x => x.Indice).IsUnique();

            ConfigureEntity(builder);
        }

        protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
    }
}