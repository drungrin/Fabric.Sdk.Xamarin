using System.Collections.Generic;

namespace Crashlytics.Sdk.Answers.Events
{
    public abstract class Base
    {
        private readonly IDictionary<string, string> _customStringAttributes = new Dictionary<string, string>();
        private readonly IDictionary<string, int> _customIntegerAttributes = new Dictionary<string, int>();
        private readonly IDictionary<string, long> _customLongAttributes = new Dictionary<string, long>();
        private readonly IDictionary<string, double> _customDoubleAttributes = new Dictionary<string, double>();

        public IDictionary<string, string> CustomStringAttributes => _customStringAttributes;
        public IDictionary<string, int> CustomIntegerAttributes => _customIntegerAttributes;
        public IDictionary<string, long> CustomLongAttributes => _customLongAttributes;
        public IDictionary<string, double> CustomDoubleAttributes => _customDoubleAttributes;
    }
}

