using Sms.Sender.Provider;

namespace Sms.Sender.Services.Providers
{
	public interface ISmsProviderFactory
	{
		ISmsProvider Create(string providerName = null);
	}
}
