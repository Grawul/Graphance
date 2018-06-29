using System.Collections.Generic;
using Graphance.Entities.Objects;

namespace Graphance.Data.Interfaces
{
    public interface IFinanceData
    {
        IEnumerable<Company> DeserializedCompanies();

        void Save(IEnumerable<Company> companies);

        void RefreshCompanies(IEnumerable<Company> companies);
    }
}