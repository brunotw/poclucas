using POCProjectAPI.Domain.Models;
using POCProjectAPI.Services.ViewModels;
using ProfileAutoMapper = AutoMapper.Profile;

namespace POCProjectAPI.Services.AutoMapper
{
    public class ViewModelToDomain : ProfileAutoMapper
    {
        public ViewModelToDomain()
        {
            CreateMap<PessoaViewModel, Pessoa>().ForMember(dest => dest.Contatos, ori => ori.MapFrom(x => x.Contatos));
            CreateMap<ContatoViewModel, Contato>();
        }
    }
}