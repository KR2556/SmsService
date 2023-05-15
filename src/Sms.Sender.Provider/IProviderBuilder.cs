using Microsoft.Extensions.DependencyInjection;

namespace Sms.Sender.Provider
{
	public interface IProviderBuilder
	{
		public IServiceCollection Services { get; }
	}
}
