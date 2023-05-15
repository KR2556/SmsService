using Microsoft.Extensions.Logging;

namespace Sms.Sender.Provider.Mock
{
	[SmsProvider("Mock")]
	public class MockSmsProvider : ISmsProvider
	{
		private readonly ILogger<MockSmsProvider> _logger;

		public MockSmsProvider(ILogger<MockSmsProvider> logger)
		{
			_logger = logger;
		}

		public Task<SmsSendResponse> SendAsync(SmsSendRequest request)
		{
			_logger.LogInformation("MockSmsProvider: Sending sms message.");

			return Task.FromResult(new SmsSendResponse());
		}
	}
}
