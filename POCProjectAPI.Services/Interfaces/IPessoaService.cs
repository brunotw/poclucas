using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Services.Interfaces
{
    public interface IPessoaService
    {
        Task<PessoaViewModel> GetPessoa(int pessoaId);
        Task<IEnumerable<PessoaViewModel>> GetPessoas();
        Task<IEnumerable<PessoaViewModel>> GetPessoasContatos();
        Task CreatePessoa(PessoaViewModel pessoa);
        Task UpdatePessoa(PessoaViewModel pessoa);
        Task DeletePessoa(PessoaViewModel pessoa);
    }
}