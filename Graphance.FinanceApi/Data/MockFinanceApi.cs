using System;
using System.Collections.Generic;
using Graphance.Entities.Objects;
using Graphance.Entities.Services;
using Graphance.FinanceApi.Interfaces;

namespace Graphance.FinanceApi.Data
{
    public class MockFinanceApi : IFinanceApi
    {
        public List<Price> GetHistoricalData(Company company)
        {
            if (company.Symbol == "GOOG")
            {
                return new List<Price>
                {
                    new Price(140.3m, new DateTime(2018, 6, 1)),
                    new Price(142.1m, new DateTime(2018, 6, 4)),
                    new Price(135.3m, new DateTime(2018, 6, 5)),
                    new Price(134.7m, new DateTime(2018, 6, 6)),
                    new Price(134.5m, new DateTime(2018, 6, 7)),
                    new Price(137.1m, new DateTime(2018, 6, 8)),
                    new Price(141.2m, new DateTime(2018, 6, 11)),
                    new Price(144.7m, new DateTime(2018, 6, 12)),
                    new Price(150.8m, new DateTime(2018, 6, 13)),
                    new Price(148.2m, new DateTime(2018, 6, 14)),
                    new Price(153.3m, new DateTime(2018, 6, 15)),
                    new Price(155.6m, new DateTime(2018, 6, 18)),
                    new Price(157.2m, new DateTime(2018, 6, 19)),
                    new Price(156.9m, new DateTime(2018, 6, 20)),
                };
            }
            if (company.Symbol == "AMZN")
            {
                return new List<Price>
                {
                    new Price(1420.3m, new DateTime(2015, 6, 1)),
                    new Price(1642.1m, new DateTime(2015, 9, 4)),
                    new Price(2255.3m, new DateTime(2015, 12, 5)),
                    new Price(1524.7m, new DateTime(2016, 3, 6)),
                    new Price(634.5m, new DateTime(2016, 6, 7)),
                    new Price(1987.1m, new DateTime(2016, 9, 8)),
                    new Price(3171.2m, new DateTime(2016, 12, 11)),
                    new Price(4664.7m, new DateTime(2017, 3, 12)),
                    new Price(3250.8m, new DateTime(2017, 6, 13)),
                    new Price(3748.2m, new DateTime(2017, 9, 14)),
                    new Price(2273.3m, new DateTime(2017, 12, 15)),
                    new Price(1555.6m, new DateTime(2018, 3, 18)),
                    new Price(1767.2m, new DateTime(2018, 6, 19)),
                    new Price(1276.9m, new DateTime(2018, 9, 20)),
                };
            }
            return new List<Price>();
        }

        public List<Price> GetLatestData(Company company)
        {
            if (company.Symbol == "GOOG")
            {
                return new List<Price>
                {
                    new Price(142.1m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(15, 30, 0))),
                    new Price(142.2m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(15, 40, 0))),
                    new Price(143.4m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(15, 50, 0))),
                    new Price(143.13m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 00, 0))),
                    new Price(142.245m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 10, 0))),
                    new Price(142.34m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 20, 0))),
                    new Price(142.41m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 30, 0))),
                    new Price(142.361m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 40, 0))),
                    new Price(142.21m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 50, 0))),
                    new Price(141.12m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(17, 00, 0))),
                    new Price(140.51m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(17, 10, 0)))
                };
            }
            if (company.Symbol == "AMZN")
            {
                return new List<Price>
                {
                    new Price(1452.122m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(15, 30, 0))),
                    new Price(1452.26m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(15, 40, 0))),
                    new Price(1452.32m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(15, 50, 0))),
                    new Price(1452.31m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 00, 0))),
                    new Price(1452.245m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 10, 0))),
                    new Price(1452.34m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 20, 0))),
                    new Price(1452.61m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 30, 0))),
                    new Price(1452.361m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 40, 0))),
                    new Price(1452.21m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(16, 50, 0))),
                    new Price(1453.12m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(17, 00, 0))),
                    new Price(1455.51m, Markets.GetLatestTradeDay(company.Market).Add(new TimeSpan(17, 10, 0)))
                };
            }
            return new List<Price>();
        }
    }
}
