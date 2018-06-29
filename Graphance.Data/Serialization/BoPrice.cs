using System;

namespace Graphance.Data.Serialization
{
    [Serializable]
    internal class BoPrice
    {
        public DateTime DateTime { get; set; }

        public decimal Value { get; set; }

        public decimal Volume { get; set; }

    }
}
