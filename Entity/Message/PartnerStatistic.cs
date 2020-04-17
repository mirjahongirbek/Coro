namespace Entity.Message
{
    public class PartnerStatistic
    {
        public string PartnerName { get; set; }
        public long SendSms { get; set; }
        public long SendOtp { get; set; }
        public long SendTelegram { get; set; }
        public string PartnerId { get; set; }
        public long NotSend { get; set; }
    }

   
}
