using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using ValdoBase.Configuration;
using ValdoBase.Domain.Entities.Aluno;

namespace ValdoBase.Database.Contexts
{
    public class ValdoBaseContext : DbContext, IValdoBaseContext
    {
        private readonly IValdoBaseConfiguration _configuration;

        public ValdoBaseContext(DbContextOptions<ValdoBaseContext> options, IValdoBaseConfiguration configuration)
            : base(options)
            => _configuration = configuration;

        public ValdoBaseContext(IValdoBaseConfiguration configuration)
            => _configuration = configuration;

        public DbSet<Aluno> Alunos { get; set; }

        public bool AllMigrationsApplied()
        {
            var idsDasMigrationJaExecutadas = this.GetService<IHistoryRepository>()
                .GetAppliedMigrations()
                .Select(m => m.MigrationId);

            var idsDeTodasAsMigrations = this.GetService<IMigrationsAssembly>()
                .Migrations
                .Select(m => m.Key);

            return !idsDeTodasAsMigrations.Except(idsDasMigrationJaExecutadas).Any();
        }

        public void DiscardChanges()
        {
            throw new NotImplementedException();
        }

        public bool ExistsItemsPendingSaveState()
        {
            var entries = ChangeTracker.Entries();
            return entries.Any(e => e.State is EntityState.Added or EntityState.Deleted or EntityState.Modified);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            if (!options.IsConfigured)
                options.UseSqlServer(_configuration.GetConnectionString(GetType().Name));

            base.OnConfiguring(options);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ValdoBaseContext).Assembly);
            base.OnModelCreating(modelBuilder);

            SetMaxLengthToStringProps(modelBuilder);
            SetTimestampTypeToDateTimeProps(modelBuilder);
        }

        private static void SetMaxLengthToStringProps(ModelBuilder modelBuilder)
        {
            var stringProps = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.PropertyInfo?.PropertyType == typeof(string))
                .ToList();

            const int defaultMaxLength = 255;
            foreach (var prop in stringProps)
            {
                var maxLength = prop.GetMaxLength();
                if (maxLength == null || maxLength <= 0 || maxLength > defaultMaxLength)
                    prop.SetMaxLength(defaultMaxLength);
            }
        }

        private static void SetTimestampTypeToDateTimeProps(ModelBuilder modelBuilder)
        {
            var dateTimeProps = modelBuilder.Model.GetEntityTypes()
                .SelectMany(x => x.GetProperties())
                .Where(x => x.PropertyInfo?.PropertyType == typeof(DateTime) || x.PropertyInfo?.PropertyType == typeof(DateTime?))
                .ToList();

            foreach (var prop in dateTimeProps)
                prop.SetColumnType("timestamp");
        }
    }
}