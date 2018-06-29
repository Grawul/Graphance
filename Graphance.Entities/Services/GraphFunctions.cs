using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Windows.Controls.DataVisualization.Charting;
using System.Windows.Media;
using Graphance.Entities.Objects;

namespace Graphance.Entities.Services
{
    public class GraphFunctions
    {
        public static SolidColorBrush GetPriceColor(IEnumerable<Price> prices)
        {
            if (prices == null) return new SolidColorBrush(Color.FromRgb(158, 158, 158));
            if (prices.FirstOrDefault()?.Value < prices.LastOrDefault()?.Value) return new SolidColorBrush(Color.FromRgb(15, 157, 88));
            if (prices.FirstOrDefault()?.Value > prices.LastOrDefault()?.Value) return new SolidColorBrush(Color.FromRgb(230, 74, 25));
            return new SolidColorBrush(Color.FromRgb(158, 158, 158));
        }

        //public static DateTimeIntervalType GetIntervalType(IEnumerable<Price> prices)
        //{
        //    if (prices?.Count() == 0) return DateTimeIntervalType.Days;

        //    var timeDistance = prices.Last().DateTime.Subtract(prices.First().DateTime);
        //    switch (GetIntervallType(timeDistance))
        //    {
        //        case IntervallType.Large: return DateTimeIntervalType.Years;
        //        case IntervallType.Years: return DateTimeIntervalType.Years;
        //        case IntervallType.Months: return DateTimeIntervalType.Months;
        //        case IntervallType.Days: return DateTimeIntervalType.Days;
        //    }
        //}

        //public static double? GetInterval(IEnumerable<Price> prices)
        //{
        //    if (prices?.Count() == 0) return 0;
        //}




        //private static IntervallType GetIntervallType(TimeSpan timeDistance)
        //{
        //    if (timeDistance.CompareTo(new TimeSpan(3650, 0, 0, 0)) > 0)
        //    {
        //        return IntervallType.Large;
        //    }
        //    if (timeDistance.CompareTo(new TimeSpan(365, 0, 0, 0)) > 0)
        //    {
        //        return IntervallType.Years;
        //    }
        //    if (timeDistance.CompareTo(new TimeSpan(30, 0, 0, 0)) > 0)
        //    {
        //        return IntervallType.Months;
        //    }

        //    return IntervallType.Days;
        //}

        //private enum IntervallType
        //{
        //    Large,
        //    Years,
        //    Months,
        //    Days
        //}
    }
}
