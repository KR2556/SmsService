namespace Sms.Sender.Client
{
	public class SmsSenderClientOptions
	{
		public const string DefaultSectionName = "SmsSenderClient";

		public Uri MessageBrokerHost { get; set; }

		public string SendSmsQueue { get; set; }
	}
}
