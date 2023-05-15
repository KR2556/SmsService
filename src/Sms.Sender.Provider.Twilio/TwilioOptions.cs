namespace Sms.Sender.Provider.Twilio
{
	public class TwilioOptions
	{
		public const string DefaultSectionName = "Twilio";

		public string AccountSid { get; set; }

		public string AuthToken { get; set; }

		public string MessagingServiceSid { get; set; }
	}
}
