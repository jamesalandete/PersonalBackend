using Business.Abstraction;
using Business.Services;
using Microsoft.Extensions.DependencyInjection;
namespace Business.Infrastructure
{
    public class RegistryRepository
    {
        public static void RegisterRepositories(IServiceCollection services)        {

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IPersonaService, PersonaService>();
            services.AddScoped<ITipoIdentificacionService, TipoIdentificacionService>();
        }
    }
}
