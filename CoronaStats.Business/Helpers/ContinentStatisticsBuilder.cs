using System.Collections.Generic;
using System.Linq;
using CoronaStats.Business.Models;

namespace CoronaStats.Business.Helpers
{

    internal static class ContinentStatisticsBuilder
    {

        public static IEnumerable<Core.Models.ContinentStatistics> BuildStatistics(List<CovidApiResponse> data)
        {
            var result = new List<Core.Models.ContinentStatistics>();
            var continents = data.Select(d => d.Continent).Distinct().ToList();

            continents.ForEach(continent => 
            {
                var continentData = data.Where(d => d.Continent == continent).ToList();


                result.Add(new Core.Models.ContinentStatistics()
                {
                    Continent = continent,
                    NewStatistics = new Core.Models.CategoryStatistics() {},
                    ActiveStatistics = new Core.Models.CategoryStatistics() {},
                    DeathStatistics = new Core.Models.CategoryStatistics() {}
                });

            });

            return result;
        }


    }

}