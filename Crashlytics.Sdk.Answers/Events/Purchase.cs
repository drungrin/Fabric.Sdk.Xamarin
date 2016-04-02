namespace Crashlytics.Sdk.Answers.Events
{
    public class Purchase
    {
        public string ItemId { get; set; }

        public string ItemName { get; set; }

        public string ItemType { get; set; }

        public double ItemPrice { get; set; }

        public string CurrencyCode { get; set; }

        public bool Success { get; set; }
    }
}

