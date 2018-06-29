using System;
using System.Collections.Generic;
using Graphance.Data.Interfaces;
using Graphance.Entities.Objects;

namespace Graphance.Data.Services
{
    public class FinanceDataService : IFinanceData
    {

        public IEnumerable<Company> DeserializedCompanies()
        {
            return SerializationService.Deserialize();
        }

        public void Save(IEnumerable<Company> companies)
        {
            SerializationService.Serialize(companies);
        }

        public void RefreshCompanies(IEnumerable<Company> companies)
        {
            CompanyPriceService.RefreshCompanies(companies);
        }


        
    }
}
