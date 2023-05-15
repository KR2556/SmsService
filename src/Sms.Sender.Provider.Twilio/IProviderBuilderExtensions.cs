using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Sms.Sender.Provider.Twilio
{
	public static class IProviderBuilderExtensions
	{
		public static IProviderBuilder AddTwilioSmsProvider(this IProviderBuilder builder, IConfiguration configuration)
		{
			var configurationSection = configuration.GetSection(TwilioOptions.DefaultSectionName);

			builder.Services.Configure<TwilioOptions>(configurationSection);
			builder.Services.AddScoped<ISmsProvider, TwilioSmsProvider>();

			return builder;
		}
	}
}
