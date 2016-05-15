namespace CrashlyticsSdk.Answers.Events
{
    public class AddToCart : Base
    {
        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; }

        public double ItemPrice { get; set; }

        public string CurrencyCode { get; set; }
    }
}