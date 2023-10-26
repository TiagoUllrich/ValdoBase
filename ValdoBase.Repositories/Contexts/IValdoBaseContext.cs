using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using ValdoBase.Domain.Entities.Aluno;

namespace ValdoBase.Database.Contexts
{
    public interface IValdoBaseContext : IDisposable
    {
        DbSet<Aluno> Alunos { get; set; }
        DatabaseFacade Database { get; }

        bool AllMigrationsApplied();

        void DiscardChanges();

        bool ExistsItemsPendingSaveState();

        int SaveChanges();

        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}