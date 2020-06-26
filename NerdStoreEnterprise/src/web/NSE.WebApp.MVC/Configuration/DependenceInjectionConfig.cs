using Microsoft.Extensions.DependencyInjection;
using NSE.WebApp.MVC.Services;

namespace NSE.WebApp.MVC.Configuration
{
    public static class DependenceInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            services.AddHttpClient<IAutenticacaoService, AutenticacaoService>();
        }
    }
}
