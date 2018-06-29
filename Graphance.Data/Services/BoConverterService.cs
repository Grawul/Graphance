using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Graphance.Data.Serialization;
using Graphance.Entities.Objects;
using Graphance.Entities.Services;

namespace Graphance.Data.Services
{
    internal class BoConverterService
    {
        internal static List<BoCompany> ConvertCompaniesFromDtoToBo(IEnumerable<Company> dtoCompanies)
        {
            return dtoCompanies.Select(ConvertCompanyFromDtoToBo).ToList();
        }


        internal static BoCompany ConvertCompanyFromDtoToBo(Company dtoCompany)
        {
            var boCompany = new BoCompany
            {
                Name = dtoCompany.Name,
                Symbol = dtoCompany.Symbol,
                Market = dtoCompany.Market.Symbol,
                HistoricalPrices = ConvertPricesFromDtoToBo(dtoCompany.HistoricalPrices),
                LatestPrices = ConvertPricesFromDtoToBo(dtoCompany.LatestPrices),

                IsFavorite = dtoCompany.IsFavorite
            };
            return boCompany;
        }

        internal static List<BoPrice> ConvertPricesFromDtoToBo(IEnumerable<Price> dtoPrices)
        {
            return dtoPrices?.Select(ConvertPriceFromDtoToBo).ToList();
        }

        internal static BoPrice ConvertPriceFromDtoToBo(Price dtoPrice)
        {
            var boPrice = new BoPrice
            {
                DateTime = dtoPrice.DateTime,
                Value = dtoPrice.Value,
                Volume = dtoPrice.Volume
            };
            return boPrice;
        }




        internal static List<Company> ConvertCompaniesFromBoToDto(IEnumerable<BoCompany> boCompanies)
        {
            return boCompanies.Select(ConvertCompanyFromBoToDto).ToList();
        }


        internal static Company ConvertCompanyFromBoToDto(BoCompany boCompany)
        {
            var dtoCompany = new Company
            {
                Name = boCompany.Name,
                Symbol = boCompany.Symbol,
                Market = Markets.All.Find(market => market.Symbol == boCompany.Market),
                HistoricalPrices = ConvertPricesFromBoToDto(boCompany.HistoricalPrices),
                LatestPrices = ConvertPricesFromBoToDto(boCompany.LatestPrices),

                IsFavorite = boCompany.IsFavorite
            };
            return dtoCompany;
        }

        internal static BindingList<Price> ConvertPricesFromBoToDto(IEnumerable<BoPrice> boPrices)
        {
            return new BindingList<Price>(boPrices?.Select(ConvertPriceFromBoToDto).ToList());
        }

        internal static Price ConvertPriceFromBoToDto(BoPrice boPrice)
        {
            var dtoPrice = new Price
            {
                DateTime = boPrice.DateTime,
                Value = boPrice.Value,
                Volume = boPrice.Volume
            };
            return dtoPrice;
        }
    }
}
