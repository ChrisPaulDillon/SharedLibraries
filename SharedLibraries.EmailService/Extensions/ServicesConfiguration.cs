using Microsoft.Extensions.DependencyInjection;
using SharedLibraries.EmailService.Models;

namespace SharedLibraries.EmailService.Extensions
{
    public static class ServicesConfiguration
    {
        public static void AddEmailServices(this IServiceCollection services, string host, int port, string userName, string password)
        {
            services.AddSingleton<IEmailConfig>(serviceProvider => new EmailConfig(host, port, userName, password));
            services.AddScoped<IEmailClient, EmailClient>();
        }
    }
}
