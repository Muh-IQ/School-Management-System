using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Modules.Communication.Domain.ThirdParty.Email;
using Modules.Communication.Domain.ThirdParty.Security;
using Modules.Communication.Infrastructure.ThirdParty.Email;
using Modules.Communication.Infrastructure.ThirdParty.Security;
using Microsoft.Extensions.Options;
using Modules.Communication.Infrastructure.Extensions;

namespace Modules.Communication.Infrastructure
{
    public static class DependencyInjectionInfrastructure
    {
        public static IServiceCollection AddInfrastructureServices(this IServiceCollection services)
        {
            var emailSettings = EmailSettingsExtensions.CreateEmailSettings();

            services.AddSingleton(Options.Create(emailSettings));

            services.AddScoped<IEmailService, EmailService>();
            services.AddSingleton<IOtpGenerator, OtpGenerator>();

            return services;
        }
    }
}
