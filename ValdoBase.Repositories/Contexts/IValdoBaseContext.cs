using Microsoft.EntityFrameworkCore;
using ValdoBase.Domain.Entities.Aluno;

namespace ValdoBase.Database.Contexts
{
    public interface IValdoBaseContext : IDisposable
    {
        DbSet<Aluno> Alunos { get; set; }

        bool AllMigrationsApplied();

        void DiscardChanges();

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}