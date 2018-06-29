using System;
using System.Collections.Generic;

namespace Graphance.Data.Serialization
{
    [Serializable]
    internal class BoCompany
    {
        public string Name { get; set; }

        public string Market { get; set; }

        public string Symbol { get; set; }

        public List<BoPrice> LatestPrices { get; set; }

        public List<BoPrice> HistoricalPrices { get; set; }


        public bool IsFavorite { get; set; }
    }
}
