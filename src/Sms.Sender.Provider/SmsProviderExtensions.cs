using System.Reflection;

namespace Sms.Sender.Provider
{
	public static class SmsProviderExtensions
	{
		public static SmsProviderAttribute GetSmsProviderAttribute(this ISmsProvider provider)
		{
			return provider.GetType().GetCustomAttribute<SmsProviderAttribute>();
		}

		public static string GetSmsProviderName(this ISmsProvider provider)
		{
			return provider.GetSmsProviderAttribute()?.Name;
		}
	}
}
