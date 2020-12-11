using System.Collections.Generic;
using System.Linq;
using CoronaStats.Business.Models;

namespace CoronaStats.Business.Helpers
{

    internal static class CountryStatisticsBuilder
    {

        public static IEnumerable<Core.Models.CountryStatistics> BuildStatistics(List<CovidApiResponse> data)
        {

            var result = new List<Core.Models.CountryStatistics>();
            data.ForEach(item => 
            {
                result.Add(new Core.Models.CountryStatistics()
                {
                    Continent = item.Continent,
                    Country = item.Country,
                    NewStatistics = new Core.Models.CategoryStatistics() {},
                    ActiveStatistics = new Core.Models.CategoryStatistics() {},
                    DeathStatistics = new Core.Models.CategoryStatistics() {}
                });

            });

            return result;
        }


    }

}