using ValdoBase.Domain.DomainObjects;

namespace ValdoBase.Domain.Entities.Aluno
{
    public class Aluno : Entity
    {
        public DateTime DataDeNascimento { get; private set; }
        public string Nome { get; private set; }
        public string NomeMae { get; private set; }
        public string NomePai { get; private set; }

        public Aluno SetDataDeNascimento(DateTime dataDeNascimento)
        {
            DataDeNascimento = dataDeNascimento;
            return this;
        }

        public Aluno SetNome(string nome)
        {
            Nome = nome;
            return this;
        }

        public Aluno SetNomeMae(string nomeMae)
        {
            NomeMae = nomeMae;
            return this;
        }

        public Aluno SetNomePai(string nomePai)
        {
            NomePai = nomePai;
            return this;
        }
    }
}