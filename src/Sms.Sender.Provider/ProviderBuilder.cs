using Microsoft.Extensions.DependencyInjection;

namespace Sms.Sender.Provider
{
	internal class ProviderBuilder : IProviderBuilder
	{
		public IServiceCollection Services { get; }

		public ProviderBuilder(IServiceCollection services)
		{
			Services = services;
		}
	}
}
