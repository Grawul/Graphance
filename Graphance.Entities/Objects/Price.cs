using System;
using Graphance.Entities.BCL;

namespace Graphance.Entities.Objects
{
    public class Price : ViewModel
    {
        private DateTime _dateTime;
        private decimal _value;
        private decimal _volume;


        public Price() { }

        public Price(decimal value, DateTime dateTime)
        {
            Value = value;
            DateTime = dateTime;
        }


        public DateTime DateTime
        {
            get { return _dateTime; }
            set { _dateTime = value; 
                PropertyChange("DateTime"); }
        }

        public decimal Value
        {
            get { return _value; }
            set { _value = value; 
                PropertyChange("Value"); }
        }

        public decimal Volume
        {
            get { return _volume; }
            set { _volume = value; 
                PropertyChange("Volume"); }
        }
    }
}
