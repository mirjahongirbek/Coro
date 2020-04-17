namespace OtpClient.Modals
{
    public class Message
    {
        public string Recipient { get; set; }
        public string MessageId { get; set; }
        public string Priority { get; set; }
        public Sms Sms { get; set; }
    }


}
