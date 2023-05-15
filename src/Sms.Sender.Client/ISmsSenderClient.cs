using Sms.Sender.DataContracts;

namespace Sms.Sender.Client
{
	public interface ISmsSenderClient
	{
		Task SendAsync(SmsDataContract sms);
	}
}
