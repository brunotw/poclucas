using Microsoft.Extensions.DependencyInjection;
using POCProjectAPI.Domain.Interfaces;
using POCProjectAPI.Infra.Data.Context;
using POCProjectAPI.Infra.Data.Repository;
using POCProjectAPI.Services.Interfaces;
using POCProjectAPI.Services.Services;

namespace POCProjectAPI.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            // Services
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IContatoService, ContatoService>();

            // Infra - Data
            services.AddScoped<AppDBContext>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<IContatoRepository, ContatoRepository>();
        }
    }
}