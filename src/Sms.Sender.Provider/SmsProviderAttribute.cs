namespace Sms.Sender.Provider
{
	public class SmsProviderAttribute : Attribute
	{
		public string Name { get; }

		public SmsProviderAttribute(string name)
		{
			Name = name;
		}
	}
}
