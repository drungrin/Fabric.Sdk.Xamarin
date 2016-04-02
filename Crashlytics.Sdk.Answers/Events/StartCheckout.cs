namespace Crashlytics.Sdk.Answers.Events
{
    public class StartCheckout : Base
    {
        public int ItemCount { get; set; }

        public double TotalPrice { get; set; }

        public string CurrencyCode { get; set; }
    }
}