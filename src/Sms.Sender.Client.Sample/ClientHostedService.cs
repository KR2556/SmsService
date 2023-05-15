using Microsoft.Extensions.Hosting;
using Sms.Sender.DataContracts;

namespace Sms.Sender.Client.Sample
{
	public class ClientHostedService : IHostedService
	{
		private readonly ISmsSenderClient _smsSenderClient;
		private readonly IHostApplicationLifetime _hostApplicationLifetime;

		public ClientHostedService(
			ISmsSenderClient smsSenderClient,
			IHostApplicationLifetime hostApplicationLifetime)
		{
			_smsSenderClient = smsSenderClient;
			_hostApplicationLifetime = hostApplicationLifetime;
		}

		public async Task StartAsync(CancellationToken cancellationToken)
		{
			await Task.Delay(2000, cancellationToken);

			Console.WriteLine("Hosted Service is running.");

			while (!cancellationToken.IsCancellationRequested)
			{
				Console.Write("Phone number: ");
				var phoneNumber = Console.ReadLine();

				Console.Write("Body: ");
				var body = Console.ReadLine();

				var sms = new SmsDataContract
				{
					PhoneNumber = phoneNumber,
					Body = body
				};

				Console.WriteLine("Sending sms message.");

				await _smsSenderClient.SendAsync(sms);

				Console.WriteLine("The sms message is sent.");
			};
		}

		public Task StopAsync(CancellationToken cancellationToken)
		{
			Console.WriteLine("Hosted Service is stopping.");

			return Task.CompletedTask;
		}
	}
}
