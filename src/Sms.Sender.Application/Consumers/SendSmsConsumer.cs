using MassTransit;
using Online.Logging;
using Sms.Sender.DataContracts;
using Sms.Sender.Provider;
using Sms.Sender.Services.Providers;

namespace Sms.Sender.Application.Consumers
{
	public class SendSmsConsumer : IConsumer<SmsDataContract>
	{
		private readonly ILogger<SendSmsConsumer> _logger;
		private readonly ISmsProviderFactory _smsProviderFactory;

		public SendSmsConsumer(
			ILogger<SendSmsConsumer> logger,
			ISmsProviderFactory smsProviderFactory)
		{
			_logger = logger;
			_smsProviderFactory = smsProviderFactory;
		}

		public async Task Consume(ConsumeContext<SmsDataContract> context)
		{
			var message = context.Message;

			using (_logger.AddProperty(nameof(message.CorrelationId), message.CorrelationId))
			{
				_logger.LogInformation("Received sms: {0}", message.SmsId);

				_logger.LogInformation("Creating sms provider...");

				var provider = _smsProviderFactory.Create(message.Provider?.ToString());

				_logger.LogInformation("Sms provider {0} is created.", provider.GetSmsProviderName());

				try
				{
					_logger.LogInformation("Sending sms: {0}", message.SmsId);

					var request = new SmsSendRequest
					{
						PhoneNumber = message.PhoneNumber,
						Body = message.Body
					};

					await provider.SendAsync(request);

					_logger.LogInformation("Sms is sent successfully: {0}", message.SmsId);
				}
				catch (Exception ex)
				{
					_logger.LogError(ex, "Failed to send the sms: {0}", message.SmsId);

					throw;
				}
			}
		}
	}
}
