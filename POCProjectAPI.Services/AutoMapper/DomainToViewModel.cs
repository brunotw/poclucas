using POCProjectAPI.Domain.Models;
using POCProjectAPI.Services.ViewModels;
using ProfileAutoMapper = AutoMapper.Profile;

namespace POCProjectAPI.Services.AutoMapper
{
    public class DomainToViewModel : ProfileAutoMapper
    {
        public DomainToViewModel()
        {
            CreateMap<Pessoa, PessoaViewModel>().ForMember(dest => dest.Contatos, ori => ori.MapFrom(x => x.Contatos));
            CreateMap<Contato, ContatoViewModel>();
        }
    }
}