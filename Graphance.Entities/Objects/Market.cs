using System;
using System.Globalization;
using Graphance.Entities.BCL;
using Graphance.Entities.Services;

namespace Graphance.Entities.Objects
{
    public class Market : ViewModel
    {
        private string _name;
        private string _symbol;
        private TimeZone _timeZone;
        private TimeSpan _openingTime;
        private TimeSpan _closingTime;
        private TimeSpan _breakBegin;
        private TimeSpan _breakEnd;





        public string Name
        {
            get { return _name; }
            set { _name = value; 
                PropertyChange("Name"); }
        }

        public string Symbol
        {
            get { return _symbol; }
            set { _symbol = value; 
                PropertyChange("Symbol"); }
        }

        public TimeZone TimeZone
        {
            get { return _timeZone; }
            set { _timeZone = value; 
                PropertyChange("TimeZone"); }
        }

        public TimeSpan OpeningTime
        {
            get { return _openingTime; }
            set { _openingTime = value; 
                PropertyChange("OpeningTime");
                PropertyChange("OpeningDateTime");
            }
        }

        public TimeSpan ClosingTime
        {
            get { return _closingTime; }
            set { _closingTime = value; 
                PropertyChange("ClosingTime");
                PropertyChange("ClosingDateTime");
            }
        }

        public TimeSpan BreakBegin
        {
            get { return _breakBegin; }
            set { _breakBegin = value; 
                PropertyChange("BreakBegin"); }
        }

        public TimeSpan BreakEnd
        {
            get { return _breakEnd; }
            set { _breakEnd = value; 
                PropertyChange("BreakEnd"); }
        }

        public DateTime OpeningDateTime => Markets.GetLatestTradeDay(this).Add(OpeningTime);
        public DateTime ClosingDateTime => Markets.GetLatestTradeDay(this).Add(ClosingTime);
        public string DateString => Markets.GetLatestTradeDay(this).ToString("dddd, dd MMMM yyyy", new CultureInfo("en-GB"));
    }
}
