using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace Sms.Sender.Provider.Twilio
{
	[SmsProvider("Twilio")]
	public class TwilioSmsProvider : ISmsProvider
	{
		private readonly TwilioOptions _options;
		private readonly ILogger<TwilioSmsProvider> _logger;

		public TwilioSmsProvider(IOptions<TwilioOptions> options, ILogger<TwilioSmsProvider> logger)
		{
			_options = options.Value;
			_logger = logger;
		}

		public async Task<SmsSendResponse> SendAsync(SmsSendRequest request)
		{
			try
			{
				_logger.LogDebug("Initializing Twilio client. AccountSid: {0}", _options.AccountSid);

				TwilioClient.Init(_options.AccountSid, _options.AuthToken);

				_logger.LogDebug("Twilio client is initialized successfully. AccountSid: {0}", _options.AccountSid);
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to initialize Twilio client. AccountSid: {0}", _options.AccountSid);

				throw;
			}

			try
			{
				_logger.LogInformation("Creating Twilio sms message.");

				var result = await MessageResource.CreateAsync(
					body: request.Body,
					to: new PhoneNumber(request.PhoneNumber),
					messagingServiceSid: _options.MessagingServiceSid
				);

				_logger.LogInformation("Twilio sms is created successfully. Status: {0}", result.Status);

				var response = new SmsSendResponse
				{
					Status = result.Status.ToString(),
					ErrorMessage = result.ErrorMessage
				};

				_logger.LogDebug("Response from Twilio: {@response}", response);

				return response;
			}
			catch (Exception ex)
			{
				_logger.LogError(ex, "Failed to creating Twilio sms message.");

				throw;
			}
		}
	}
}
