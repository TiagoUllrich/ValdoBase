using Bogus;
using ValdoBase.Database.Contexts;
using ValdoBase.Domain.Entities.Aluno;

namespace ValdoBase.Database.Seed.Alunos
{
    public class AlunosSeed
    {
        private readonly IValdoBaseContext _context;

        public AlunosSeed(IValdoBaseContext context)
            => _context = context;

        public void Execute()
            => GerarAlunos();

        private void GerarAlunos()
        {
            var aluno = _context.Alunos.FirstOrDefault();
            if (aluno is null)
            {
                Faker faker = new();
                List<Aluno> alunos = new();

                for (int i = 0; i < faker.Random.Int(min: 2, max: 20); i++)
                {
                    aluno = new Aluno()
                        .SetDataDeNascimento(faker.Person.DateOfBirth)
                        .SetNome(faker.Person.FullName);

                    alunos.Add(aluno);
                }

                _context.Alunos.AddRange(alunos);
            }

            if (_context.ExistsItemsPendingSaveState())
                _context.SaveChanges();
        }
    }
}