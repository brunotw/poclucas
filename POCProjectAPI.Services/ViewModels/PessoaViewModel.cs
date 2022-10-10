using System.Collections.ObjectModel;

namespace POCProjectAPI.Services.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Contatos = new Collection<ContatoViewModel>();
        }

        public int PessoaId { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public string Sexo { get; set; }

        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}