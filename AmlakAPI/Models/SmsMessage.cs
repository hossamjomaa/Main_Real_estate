namespace AmlakAPI.Models
{
    public class SmsMessage
    {
        public string Number { get; set; }
        public string Message { get; set; }
        public string Key { get; internal set; }
    }
}
