using ValdoBase.Domain.DomainObjects;

namespace ValdoBase.Domain.Entities.Aluno
{
    public class Aluno : Entity
    {
        public Aluno(string nome, DateTime dataDeNascimento)
        {
            SetId(Guid.NewGuid());
            SetNome(nome);
            SetDataDeNascimento(dataDeNascimento);
        }

        public DateTime DataDeNascimento { get; private set; }
        public Guid Id { get; private set; }
        public string Nome { get; private set; }

        public void SetDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
        }

        public void SetId(Guid guid)
        {
            Id = guid;
        }

        public void SetNome(string nome)
        {
            Nome = nome;
        }
    }
}