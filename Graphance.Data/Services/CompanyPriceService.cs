using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Graphance.Entities.Objects;
using Graphance.Entities.Services;
using Graphance.FinanceApi.Data;
using Graphance.FinanceApi.Interfaces;

namespace Graphance.Data.Services
{
    internal class CompanyPriceService
    {
        internal static void RefreshCompanies(IEnumerable<Company> companies)
        {
            IFinanceApi financeApi = new MockFinanceApi();

            foreach (var company in companies)
            {
                CreatePriceLists(company);

                if (company.HistoricalPrices.LastOrDefault()?.DateTime.Date != DateTime.Today)
                {
                    var historicalPrices = financeApi.GetHistoricalData(company);

                    foreach (var price in historicalPrices)
                    {
                        if (company.HistoricalPrices.All(x => x.DateTime != price?.DateTime))
                        {
                            company.HistoricalPrices.Add(price);
                        }
                    }
                }

                var latestPrices = financeApi.GetLatestData(company);

                foreach (var price in latestPrices)
                {
                    if (company.LatestPrices.All(x => x.DateTime != price?.DateTime))
                    {
                        company.LatestPrices.Add(price);
                    }
                }
            }
        }

        private static void CreatePriceLists(Company company)
        {
            if (company.HistoricalPrices == null) company.HistoricalPrices = new BindingList<Price>();
            if (company.LatestPrices == null) company.LatestPrices = new BindingList<Price>();

            var latestPriceDay = Markets.GetLatestTradeDay(company.Market);
            if (company.LatestPrices.Any(price => price.DateTime.Date != latestPriceDay)) company.LatestPrices = new BindingList<Price>();
        }
    }
}
