using POCProjectAPI.Domain.Models;
using System.Text.Json.Serialization;

namespace POCProjectAPI.Services.ViewModels
{
    public class ContatoViewModel
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }

        public int PessoaId { get; set; }
        [JsonIgnore]
        public Pessoa Pessoa { get; set; }
    }
}