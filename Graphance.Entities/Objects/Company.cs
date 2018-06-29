using System;
using System.ComponentModel;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;
using Graphance.Entities.BCL;
using Graphance.Entities.Services;

namespace Graphance.Entities.Objects
{
    public class Company : ViewModel
    {
        private string _name;
        private Market _market;
        private string _symbol;
        private BindingList<Price> _latestPrices;
        private BindingList<Price> _historicalPrices;

        private bool _isFavorite;

        public Company() { }

        public Company(string name, string symbol, Market market)
        {
            Name = name;
            Symbol = symbol;
            Market = market;
        }



        public string Name
        {
            get { return _name; }
            set { _name = value;
                PropertyChange("Name"); }
        }

        public Market Market
        {
            get { return _market; }
            set { _market = value; 
                PropertyChange("Market"); }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; 
                PropertyChange("Symbol"); }
        }

        public BindingList<Price> LatestPrices
        {
            get { return _latestPrices; }
            set { _latestPrices = value; 
                PropertyChange("LatestPrices");
                PropertyChange("LatestColor");
            }
        }

        public BindingList<Price> HistoricalPrices
        {
            get { return _historicalPrices; }
            set { _historicalPrices = value; 
                PropertyChange("HistoricalPrices");
                PropertyChange("HistoricalColor");
                PropertyChange("IntervalType");
            }
        }

        public bool IsFavorite
        {
            get { return _isFavorite; }
            set { _isFavorite = value;
                PropertyChange("IsFavorite");
            }
        }

        public SolidColorBrush LatestColor => GraphFunctions.GetPriceColor(LatestPrices);
        public SolidColorBrush HistoricalColor => GraphFunctions.GetPriceColor(HistoricalPrices);
        //public DateTimeIntervalType IntervalType => GraphFunctions.GetIntervalType(HistoricalPrices);
        //public double? Intervall => GraphFunctions.GetInterval(HistoricalPrices);
    }
}
