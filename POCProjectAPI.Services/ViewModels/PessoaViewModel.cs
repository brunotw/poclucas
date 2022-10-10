using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace POCProjectAPI.Services.ViewModels
{
    public class PessoaViewModel
    {
        public PessoaViewModel()
        {
            Contatos = new Collection<ContatoViewModel>();
        }

        public int PessoaId { get; set; }

        [Required]
        [MinLength(5)]
        public string Nome { get; set; }

        [Required]
        [Range(18,120)]
        public int Idade { get; set; }

        [Required]
        [RegularExpression("M|F", ErrorMessage = "Sexo deve ser 'M' ou 'F' apenas.")]
        public string Sexo { get; set; }

        public ICollection<ContatoViewModel> Contatos { get; set; }
    }
}