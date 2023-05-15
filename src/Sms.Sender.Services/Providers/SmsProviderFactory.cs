using Microsoft.Extensions.Options;
using Sms.Sender.Provider;
using Sms.Sender.Services.Configurations;

namespace Sms.Sender.Services.Providers
{
	public class SmsProviderFactory : ISmsProviderFactory
	{
		private readonly ProviderOptions _options;
		private readonly IEnumerable<ISmsProvider> _smsProviders;

		public SmsProviderFactory(IOptions<ProviderOptions> options, IEnumerable<ISmsProvider> smsProviders)
		{
			_options = options.Value;
			_smsProviders = smsProviders;
		}

		public ISmsProvider Create(string providerName = null)
		{
			if (string.IsNullOrEmpty(providerName))
			{
				providerName = _options.DefaultProvider;
			}

			if (string.IsNullOrEmpty(providerName))
			{
				throw new Exception($"Sms provider is not provided.");
			}

			var provider = _smsProviders
				.FirstOrDefault(p => string.Equals(providerName, p.GetSmsProviderName(), StringComparison.InvariantCultureIgnoreCase));

			if (provider == null)
			{
				throw new NotImplementedException($"No implementation found for '{providerName}' provider.");
			}

			return provider;
		}
	}
}
