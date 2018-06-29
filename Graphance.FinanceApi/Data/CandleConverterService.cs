using System.Collections.Generic;
using Graphance.Entities.Objects;
using Nuba.Finance.Google;

namespace Graphance.FinanceApi.Data
{
    internal class CandleConverterService
    {
        internal static List<Price> ConvertCandleToPrice(IEnumerable<Candle> candles)
        {
            var prices = new List<Price>();

            foreach (var candle in candles)
            {
                prices.Add(new Price
                    {
                        DateTime = candle.Date,
                        Value = candle.Close,
                        Volume = candle.Volume
                    });
            }

            return prices;
        }
    }
}
