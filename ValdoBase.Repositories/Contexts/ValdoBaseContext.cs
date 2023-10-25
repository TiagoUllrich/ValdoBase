using Microsoft.EntityFrameworkCore;
using ValdoBase.Domain.Entities.Aluno;

namespace ValdoBase.Database.Contexts
{
    public class ValdoBaseContext : DbContext, IValdoBaseContext
    {
        public DbSet<Aluno> Alunos { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public bool AllMigrationsApplied()
        {
            throw new NotImplementedException();
        }

        public void DiscardChanges()
        {
            throw new NotImplementedException();
        }
    }
}