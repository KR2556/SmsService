using Microsoft.Extensions.Options;
using MassTransit;
using Sms.Sender.DataContracts;

namespace Sms.Sender.Client
{
	internal class SmsSenderClient : ISmsSenderClient
	{
		private readonly SmsSenderClientOptions _options;
		private readonly ISendEndpointProvider _sendEndpointProvider;

		public SmsSenderClient(
			IOptions<SmsSenderClientOptions> options,
			ISendEndpointProvider sendEndpointProvider)
		{
			_options = options.Value;
			_sendEndpointProvider = sendEndpointProvider;
		}

		public async Task SendAsync(SmsDataContract smsDataContract)
		{
			if (smsDataContract.CorrelationId == Guid.Empty)
			{
				smsDataContract.CorrelationId = Guid.NewGuid();
			}

			await SendAsync(smsDataContract, _options.SendSmsQueue);
		}

		private async Task SendAsync(object message, string endpointQueueName)
		{
			var endpoint = GetQueueUri(endpointQueueName);
			var sendEndpoint = await _sendEndpointProvider.GetSendEndpoint(endpoint);

			await sendEndpoint.Send(message);
		}

		private Uri GetQueueUri(string queueName)
		{
			return new Uri($"queue:{queueName}");
		}
	}
}
