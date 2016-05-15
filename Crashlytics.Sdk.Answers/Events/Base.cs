using System.Collections.Generic;

namespace CrashlyticsSdk.Answers.Events
{
    public abstract class Base
    {
        public IDictionary<string, string> CustomStringAttributes { get; } = new Dictionary<string, string>();

        public IDictionary<string, int> CustomIntegerAttributes { get; } = new Dictionary<string, int>();

        public IDictionary<string, long> CustomLongAttributes { get; } = new Dictionary<string, long>();

        public IDictionary<string, double> CustomDoubleAttributes { get; } = new Dictionary<string, double>();
    }
}