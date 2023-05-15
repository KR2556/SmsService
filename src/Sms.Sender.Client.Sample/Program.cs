using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Sms.Sender.Client;
using Sms.Sender.Client.Sample;

var host = Host.CreateDefaultBuilder(args)
	.ConfigureServices((context, services) =>
	{
		services.AddSmsSenderClient(context.Configuration.GetSection(SmsSenderClientOptions.DefaultSectionName));
		services.AddHostedService<ClientHostedService>();
	})
	.UseConsoleLifetime()
	.Build();

host.Run();
