namespace Sms.Sender.Provider
{
	public interface ISmsProvider
	{
		Task<SmsSendResponse> SendAsync(SmsSendRequest request);
	}
}
