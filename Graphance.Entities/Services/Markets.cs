using System;
using System.Collections.Generic;
using Graphance.Entities.Objects;

namespace Graphance.Entities.Services
{
    public class Markets
    {
        public static List<Market> All => new List<Market>
        {
            NYSE,
            NASDAQ,
            Xetra
        };


        public static Market NYSE = new Market
        {
            Name = "New York Stock Exchange",
            Symbol = "NYSE",
            OpeningTime = new TimeSpan(15, 30, 0),
            ClosingTime = new TimeSpan(22, 00, 0)
        };
        
        public static Market NASDAQ = new Market
        {
            Name = "Nasdaq Stock Market",
            Symbol = "NASDAQ",
            OpeningTime = new TimeSpan(15, 30, 0),
            ClosingTime = new TimeSpan(22, 00, 0)
        };

        public static Market Xetra = new Market
        {
            Name = "Xetra",
            Symbol = "ETR",
            OpeningTime = new TimeSpan(8, 00, 0),
            ClosingTime = new TimeSpan(22, 00, 0)
        };

        


        public static DateTime GetLatestTradeDay(Market market)
        {
            if (DateTime.Today.DayOfWeek == DayOfWeek.Saturday)
            {
                return DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0));
            }
            if (DateTime.Today.DayOfWeek == DayOfWeek.Sunday)
            {
                return DateTime.Today.Subtract(new TimeSpan(2, 0, 0, 0));
            }

            if (DateTime.Now.TimeOfDay < market.OpeningTime)
            {
                return DateTime.Today.Subtract(new TimeSpan(1, 0, 0, 0));
            }

            return DateTime.Today;
        }
    }
}
