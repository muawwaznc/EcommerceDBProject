using Microsoft.Extensions.DependencyInjection;
using EcommerceDBProject.Services.Interface;
using EcommerceDBProject.Services.Service;

namespace EcommerceDBProject.AppRegister
{
    public class AppService
    {
        public AppService(IServiceCollection services)
        {
            services.AddTransient<IUserInterface, UserService>();
        }

    }
}