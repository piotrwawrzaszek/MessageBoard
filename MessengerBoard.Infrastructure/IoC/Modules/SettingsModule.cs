using Autofac;
using MessengerBoard.Infrastructure.Settings;
using Microsoft.Extensions.Configuration;
using MessengerBoard.Infrastructure.Extensions;

namespace MessengerBoard.Infrastructure.IoC.Modules
{
    public class SettingsModule : Autofac.Module
    {
        private readonly IConfiguration _configuration;

        public SettingsModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterInstance(_configuration.GetSettings<GeneralSettings>())
                   .SingleInstance();

            builder.RegisterInstance(_configuration.GetSettings<JwtSettings>())
                .SingleInstance();
        }
    }
}
