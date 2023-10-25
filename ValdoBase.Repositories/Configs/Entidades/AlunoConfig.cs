using Microsoft.EntityFrameworkCore.Metadata.Builders;
using ValdoBase.Domain.Entities.Aluno;

namespace ValdoBase.Database.Configs.Entidades
{
    public class AlunoConfig : BaseEntityConfig<Aluno>
    {
        protected override void ConfigureEntity(EntityTypeBuilder<Aluno> builder)
        {
            builder.Property(x => x.DataDeNascimento).IsRequired();
            builder.Property(x => x.Nome).IsRequired();
        }
    }
}