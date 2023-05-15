namespace Sms.Sender.DataContracts
{
	public class SmsResponseDataContract
	{
		public Guid CorrelationId { get; set; }

		public int SmsId { get; set; }

		public string From { get; set; }

		public string Status { get; set; }

		public string ErrorMessage { get; set; }
	}
}
