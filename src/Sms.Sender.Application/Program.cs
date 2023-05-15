using Sms.Sender.Services;
using Sms.Sender.Application;

var builder = WebApplication.CreateBuilder(args);

builder.Host
	.ConfigureLogging(logging =>
	{
		logging.AddConsole();
	})
	.ConfigureServices((context, services) =>
	{
		services.AddProviders(context.Configuration);
		services.AddConsumers(context.Configuration);
	});

var app = builder.Build();

app.Run();
