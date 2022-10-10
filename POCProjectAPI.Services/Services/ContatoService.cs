using AutoMapper;
using POCProjectAPI.Domain.Interfaces;
using POCProjectAPI.Domain.Models;
using POCProjectAPI.Services.Interfaces;
using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Services.Services
{
    public class ContatoService : IContatoService
    {
        public readonly IContatoRepository _contatoRepository;
        public readonly IMapper _mapper;

        public ContatoService(IContatoRepository contatoRepository, IMapper mapper)
        {
            _contatoRepository = contatoRepository;
            _mapper = mapper;
        }

        public async Task<ContatoViewModel> GetContato(int contatoId) => _mapper.Map<ContatoViewModel>(await _contatoRepository.GetContato(contatoId));

        public async Task<IEnumerable<ContatoViewModel>> GetContatos(int pessoaId) => _mapper.Map<IEnumerable<ContatoViewModel>>(await _contatoRepository.GetContatos(pessoaId));

        public async Task CreateContato(ContatoViewModel contato) => await _contatoRepository.CreateContato(_mapper.Map<Contato>(contato));

        public async Task UpdateContato(ContatoViewModel contato) => await _contatoRepository.UpdateContato(_mapper.Map<Contato>(contato));

        public async Task DeleteContato(ContatoViewModel contato) => await _contatoRepository.DeleteContato(_mapper.Map<Contato>(contato));
    }
}