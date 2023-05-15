using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sms.Sender.Provider;
using Sms.Sender.Provider.Mock;
using Sms.Sender.Provider.Twilio;
using Sms.Sender.Services.Configurations;
using Sms.Sender.Services.Providers;

namespace Sms.Sender.Services
{
	public static class ServiceCollectionExtensions
	{
		public static IServiceCollection AddProviders(this IServiceCollection services, IConfiguration configuration)
		{
			var configurationSection = configuration.GetSection(ProviderOptions.DefaultSectionName);

			services.Configure<ProviderOptions>(configurationSection);

			services.AddSmsProviders(builder =>
			{
				builder.AddMockSmsProvider();
				builder.AddTwilioSmsProvider(configuration);
			});

			services.AddScoped<ISmsProviderFactory, SmsProviderFactory>();

			return services;
		}
	}
}
