using System;

namespace Crashlytics.Sdk.Answers.Events
{
    public class StartCheckout
    {
        public int ItemCount { get; set; }

        public double TotalPrice { get; set; }

        public string CurrencyCode { get; set; }
    }
}

