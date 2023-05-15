using Microsoft.Extensions.DependencyInjection;

namespace Sms.Sender.Provider.Mock
{
	public static class IProviderBuilderExtensions
	{
		public static IProviderBuilder AddMockSmsProvider(this IProviderBuilder builder)
		{
			builder.Services.AddScoped<ISmsProvider, MockSmsProvider>();

			return builder;
		}
	}
}
