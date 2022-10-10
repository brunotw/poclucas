namespace POCProjectAPI.Domain.Models
{
    public class Contato
    {
        public int ContatoId { get; set; }
        public string Nome { get; set; }
        public string Conteudo { get; set; }

        public int PessoaId { get; set; }
        public Pessoa Pessoa { get; set; }
    }
}