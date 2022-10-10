using AutoMapper;
using POCProjectAPI.Domain.Interfaces;
using POCProjectAPI.Domain.Models;
using POCProjectAPI.Services.Interfaces;
using POCProjectAPI.Services.ViewModels;

namespace POCProjectAPI.Services.Services
{
    public class PessoaService : IPessoaService
    {
        public readonly IPessoaRepository _pessoaRepository;
        public readonly IMapper _mapper;

        public PessoaService(IPessoaRepository pessoaRepository, IMapper mapper)
        {
            _pessoaRepository = pessoaRepository;
            _mapper = mapper;
        }

        public async Task<PessoaViewModel> GetPessoa(int pessoaId) => _mapper.Map<PessoaViewModel>(await _pessoaRepository.GetPessoa(pessoaId));

        public async Task<IEnumerable<PessoaViewModel>> GetPessoas() => _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.GetPessoas());

        public async Task<IEnumerable<PessoaViewModel>> GetPessoasContatos() => _mapper.Map<IEnumerable<PessoaViewModel>>(await _pessoaRepository.GetPessoasContatos());

        public async Task CreatePessoa(PessoaViewModel pessoa) => await _pessoaRepository.CreatePessoa(_mapper.Map<Pessoa>(pessoa));

        public async Task UpdatePessoa(PessoaViewModel pessoa) => await _pessoaRepository.UpdatePessoa(_mapper.Map<Pessoa>(pessoa));

        public async Task DeletePessoa(PessoaViewModel pessoa) => await _pessoaRepository.DeletePessoa(_mapper.Map<Pessoa>(pessoa));
    }
}