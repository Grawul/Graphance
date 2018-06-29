using System.Collections.Generic;
using Graphance.Entities.Objects;

namespace Graphance.FinanceApi.Interfaces
{
    public interface IFinanceApi
    {
        List<Price> GetHistoricalData(Company company);

        List<Price> GetLatestData(Company company);
    }
}