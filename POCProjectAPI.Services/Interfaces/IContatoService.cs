using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Services.Interfaces
{
    public interface IContatoService
    {
        Task<ContatoViewModel> GetContato(int contatoId);
        Task<IEnumerable<ContatoViewModel>> GetContatos(int pessoaId);
        Task CreateContato(ContatoViewModel contato);
        Task UpdateContato(ContatoViewModel contato);
        Task DeleteContato(ContatoViewModel contato);
    }
}