using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MassTransit;

namespace Sms.Sender.Client
{
	public static class IServiceCollectionExtensions
	{
		/// <summary>
		/// Add ISmsSenderClient client to use Sms.Sender microservice.
		/// </summary>
		/// <param name="services">Instance of the IServiceCollection</param>
		/// <param name="configurationSection"></param>
		/// <returns></returns>
		public static IServiceCollection AddSmsSenderClient(this IServiceCollection services, IConfigurationSection configurationSection)
		{
			var options = configurationSection.Get<SmsSenderClientOptions>();

			services.Configure<SmsSenderClientOptions>(configurationSection);

			services.AddScoped<ISmsSenderClient, SmsSenderClient>();

			if (!services.IsMessageBrokerRegistered())
			{
				services.AddMassTransit(x =>
				{
					x.UsingRabbitMq((context, cfg) =>
					{
						cfg.Host(options.MessageBrokerHost);
					});
				});
			}

			return services;
		}

		static bool IsMessageBrokerRegistered(this IServiceCollection services)
		{
			var isRegistered = services.Any(x => x.ServiceType == typeof(IBus));

			return isRegistered;
		}
	}
}
