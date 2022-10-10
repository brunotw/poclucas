using System.Collections.ObjectModel;

namespace POCProjectAPI.Domain.Models
{
    public class Pessoa
    {
        protected Pessoa()
        {
            Contatos = new Collection<Contato>();
        }

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }

        public ICollection<Contato> Contatos { get; set; }
    }
}