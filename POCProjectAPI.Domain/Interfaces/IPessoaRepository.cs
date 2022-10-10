using POCProjectAPI.Domain.Models;

namespace POCProjectAPI.Domain.Interfaces
{
    public interface IPessoaRepository
    {
        Task<Pessoa> GetPessoa(int pessoaId);
        Task<IEnumerable<Pessoa>> GetPessoas();
        Task<IEnumerable<Pessoa>> GetPessoasContatos();
        Task CreatePessoa(Pessoa pessoa);
        Task UpdatePessoa(Pessoa pessoa);
        Task DeletePessoa(Pessoa pessoa);
    }
}