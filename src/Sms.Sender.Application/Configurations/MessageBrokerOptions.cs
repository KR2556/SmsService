namespace Sms.Sender.Application.Configurations
{
	public class MessageBrokerOptions
	{
		public const string DefaultSectionName = "MessageBroker";

		public Uri Host { get; set; }

		public string SendSmsQueue { get; set; }
	}
}
