namespace Sms.Sender.DataContracts
{
	public class SmsDataContract
	{
		public Guid CorrelationId { get; set; }

		public int SmsId { get; set; }

		public string PhoneNumber { get; set; }

		public string Body { get; set; }

		public SmsProvider? Provider { get; set; }
	}
}
