using POCProjectAPI.Domain.Models;

namespace POCProjectAPI.Domain.Interfaces
{
    public interface IContatoRepository
    {
        Task<Contato> GetContato(int contatoId);
        Task<IEnumerable<Contato>> GetContatos(int pessoaId);
        Task CreateContato(Contato contato);
        Task UpdateContato(Contato contato);
        Task DeleteContato(Contato contato);
    }
}