//using MassTransit;
//using Sms.Sender.Application.Configurations;
//using Sms.Sender.Application.Consumers;

//namespace Sms.Sender.Application
//{
//	public static class ServiceCollectionExtensions
//	{
//		public static IServiceCollection AddConsumers(this IServiceCollection services, IConfiguration configuration)
//		{
//			var options = configuration
//				.GetSection(MessageBrokerOptions.DefaultSectionName)
//				.Get<MessageBrokerOptions>();

//			services.AddMassTransit(x =>
//			{
//				x.AddConsumer<SendSmsConsumer>();

//				x.UsingRabbitMq((context, cfg) =>
//				{
//					cfg.ReceiveEndpoint(options.SendSmsQueue, e =>
//					{
//						e.ConfigureConsumer<SendSmsConsumer>(context);
//					});

//					cfg.Host(options.Host);
//				});
//			});

//			return services;
//		}
//	}
//}
