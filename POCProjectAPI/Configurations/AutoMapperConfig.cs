using POCProjectAPI.Services.AutoMapper;

namespace POCProjectAPI.Configurations
{
    public static class AutoMapperConfig
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(DomainToViewModel), typeof(ViewModelToDomain));
        }
    }
}