using System.ComponentModel;
using System.Linq;
using Graphance.Data.Interfaces;
using Graphance.Data.Services;
using Graphance.Entities.BCL;
using Graphance.Entities.Objects;

namespace Graphance.UI.ViewModels
{
    public class FinanceViewModel : ViewModel
    {
        private readonly IFinanceData _financeData;

        private BindingList<Company> _companies;


        public FinanceViewModel()
        {
            _financeData = new FinanceDataService();
            Companies = new BindingList<Company>(_financeData.DeserializedCompanies().ToList());

            RefreshPrices();
            // https://github.com/dotnetprojects/WpfToolkit/blob/master/WpfToolkit/DataVisualization/Charting/Axis/DisplayAxis.cs
        }



        public void RefreshPrices()
        {
            _financeData.RefreshCompanies(Companies);
            PropertyChange("");
        }

        public void Save()
        {
            _financeData.Save(Companies);
        }




        public BindingList<Company> Companies
        {
            get => _companies;
            set
            {
                _companies = value; 
                PropertyChange("Companies");
            }
        }
    }
}
