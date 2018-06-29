using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using Graphance.Data.Serialization;
using Graphance.Entities.Objects;

namespace Graphance.Data.Services
{
    internal class SerializationService
    {
        internal static string SaveDirectory = $"{Environment.CurrentDirectory}/Companies";
        internal static string SavePattern = ".$$$";

        internal static IEnumerable<Company> Deserialize()
        {
            if (!Directory.Exists(SaveDirectory))
            {
                return new List<Company>();
            }

            var companyFiles = Directory.GetFiles(SaveDirectory, $"*{SavePattern}");

            return companyFiles.Select(DeserializeCompany).ToList();
        }


        internal static void Serialize(IEnumerable<Company> companies)
        {
            if (companies?.Any(x => x == null) ?? true) return;
            
            if (!Directory.Exists(SaveDirectory))
            {
                Directory.CreateDirectory(SaveDirectory);
            }

            foreach (var company in companies)
            {
                SerializeCompany(company);
            }
        }




        internal static Company DeserializeCompany(string file)
        {
            var bf = new BinaryFormatter();
            var fs = new FileStream(file, FileMode.Open);

            try
            {
                var boCompany = bf.Deserialize(fs) as BoCompany;
                return BoConverterService.ConvertCompanyFromBoToDto(boCompany);
            }
            catch (Exception e)
            {
                // Log or something... Or blame the cows... Cows are always responsible!
            }
            finally
            {
                fs.Dispose();
            }

            return null;
        }


        internal static void SerializeCompany(Company company)
        {
            var fileName = $"{SaveDirectory}/{company.Symbol}{SavePattern}";
            var bf = new BinaryFormatter();
            var fs = new FileStream(fileName, FileMode.Create);

            try
            {
                var boCompany = BoConverterService.ConvertCompanyFromDtoToBo(company);
                bf.Serialize(fs, boCompany);
            }
            catch (Exception e)
            {
                // Log or something... Or blame the cows... Cows are always responsible!
            }
            finally
            {
                fs.Dispose();
            }
        }



    }
}
