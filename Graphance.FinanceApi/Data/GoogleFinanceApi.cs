using System;
using System.Collections.Generic;
using Graphance.Entities.Objects;
using Graphance.FinanceApi.Interfaces;
using Nuba.Finance.Google;

namespace Graphance.FinanceApi.Data
{
    public class GoogleFinanceApi : IFinanceApi
    {
        public List<Price> GetHistoricalData(Company company)
        {
            try
            {
                var lqs = new LatestQuotesService();
                var candles = lqs.GetValues
                (
                    company.Market.Symbol, 
                    company.Symbol, 
                    Frequency.EveryNMinutes(10), 
                    DateTime.Today.Subtract(new TimeSpan(500, 0, 0, 0)), 
                    DateTime.Now
                );
                return CandleConverterService.ConvertCandleToPrice(candles);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Price> GetLatestData(Company company)
        {
            try
            {
                var lqs = new LatestQuotesService();
                var candles = lqs.GetValues
                (
                    company.Market.Symbol,
                    company.Symbol,
                    Frequency.EveryNSeconds(10),
                    company.Market.OpeningDateTime,
                    DateTime.Now
                );
                return CandleConverterService.ConvertCandleToPrice(candles);
            }
            catch (Exception)
            {
                return null;
            }
        }



    }
}
