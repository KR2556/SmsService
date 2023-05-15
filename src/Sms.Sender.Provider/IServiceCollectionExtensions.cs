using Microsoft.Extensions.DependencyInjection;

namespace Sms.Sender.Provider
{
	public static class IServiceCollectionExtensions
	{
		public static IServiceCollection AddSmsProviders(this IServiceCollection services, Action<IProviderBuilder> configureAction)
		{
			var builder = new ProviderBuilder(services);

			configureAction(builder);

			return services;
		}
	}
}
