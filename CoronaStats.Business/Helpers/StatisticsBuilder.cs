using System;
using System.Collections.Generic;
using System.Linq;
using CoronaStats.Business.Models;

namespace CoronaStats.Business.Helpers
{

    internal static class StatisticsBuilder
    {

        #region Public Methods
        public static IEnumerable<Core.Models.CountryStatistics> BuildCountryStatistics(List<CovidApiResponse> input)
        {
            var result = new List<Core.Models.CountryStatistics>();
            var continents = input.Where(x => x.Continent != "All").Select(d => d.Continent).Distinct().ToList();

            // Calculate the totals for the global statistics
            
            continents.ForEach(continent =>
            {
                var continentData = input.Where(d => d.Continent == continent).ToList();
                // Calculate the totals per continent
                var continentTotalNewCases = GetTotalNumberOfNewCases(continentData);
                var continentTotalActiveCases = GetTotalNumberOfActiveCases(continentData);
                var continentTotalDeaths = GetTotalNumberOfDeaths(continentData);

                // Get the distinct countries in the continent
                var countries = continentData.Select(d => d.Country).Distinct().ToList();

                countries.ForEach(country =>
                {
                    var countryData = continentData.Where(x => x.Country == country).ToList();

                    // Calculate the country statistics
                    var countryTotalNewCases = GetTotalNumberOfNewCases(countryData);
                    var countryTotalActiveCases = GetTotalNumberOfActiveCases(countryData);
                    var countryTotalDeaths = GetTotalNumberOfDeaths(countryData);

                    // Add the output model
                    result.Add(new Core.Models.CountryStatistics()
                    {
                        Continent = continent,
                        Country = country,
                        NewStatistics = new Core.Models.CategoryStatistics()
                        {
                            Total = countryTotalNewCases,
                            Percent = CalculatePercentage(continentTotalNewCases, countryTotalNewCases)
                        },

                        ActiveStatistics = new Core.Models.CategoryStatistics()
                        {
                            Total = countryTotalActiveCases,
                            Percent = CalculatePercentage(continentTotalActiveCases, countryTotalActiveCases)
                        },
                        DeathStatistics = new Core.Models.CategoryStatistics()
                        {
                            Total = countryTotalDeaths,
                            Percent = CalculatePercentage(continentTotalDeaths, countryTotalDeaths)
                        }
                    });
                });
            });

            return result;
        }

        public static IEnumerable<Core.Models.ContinentStatistics> BuildContinentStatistics(List<CovidApiResponse> input)
        {
            var result = new List<Core.Models.ContinentStatistics>();
            var continents = input.Where(x => x.Continent != "All").Select(d => d.Continent).Distinct().ToList();

            // Calculate the totals for the global statistics
            var globalTotalNewCases = GetTotalNumberOfNewCases(input);
            var globalTotalActiveCases = GetTotalNumberOfActiveCases(input);
            var globalTotalDeaths = GetTotalNumberOfDeaths(input);

            continents.ForEach(continent => 
            {
                var continentData = input.Where(d => d.Continent == continent).ToList();
                
                // Calculate the continent statistics
                var continentTotalNewCases = GetTotalNumberOfNewCases(continentData);
                var continentTotalActiveCases = GetTotalNumberOfActiveCases(continentData);
                var continentTotalDeaths = GetTotalNumberOfDeaths(continentData);

                // Add the output model
                result.Add(new Core.Models.ContinentStatistics()
                {
                    Continent = continent,
                    NewStatistics = new Core.Models.CategoryStatistics() 
                    {
                        Total = continentTotalNewCases,
                        Percent = CalculatePercentage(globalTotalNewCases, continentTotalNewCases)
                    },

                    ActiveStatistics = new Core.Models.CategoryStatistics() 
                    {
                        Total = continentTotalActiveCases,
                        Percent = CalculatePercentage(globalTotalActiveCases, continentTotalActiveCases)
                    },
                    DeathStatistics = new Core.Models.CategoryStatistics() 
                    {
                        Total = continentTotalDeaths,
                        Percent = CalculatePercentage(globalTotalDeaths, continentTotalDeaths)
                    }
                });

            });

            return result;
        }
        #endregion

        #region Private Methods
        /// <summary>
        /// Calculates the total of new cases from the input list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static int GetTotalNumberOfNewCases(List<CovidApiResponse> data)
        {
            if (data == null && data.Count == 0)
            {
                return 0;
            }
            int result = data.Where(x => !string.IsNullOrWhiteSpace(x.Cases?.New)).Select(x => int.Parse(x.Cases.New)).Sum();
            return result;
        }

        /// <summary>
        /// Calculates the total of active cases from the input list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static int GetTotalNumberOfActiveCases(List<CovidApiResponse> data)
        {
            if (data == null && data.Count == 0)
            {
                return 0;
            }
            int result = data.Where(x => x.Cases.Active.HasValue).Select(x => x.Cases.Active.Value).Sum();
            return result;
        }

        /// <summary>
        /// Calculates the total of deaths from the input list
        /// </summary>
        /// <param name="data"></param>
        /// <returns></returns>
        private static int GetTotalNumberOfDeaths(List<CovidApiResponse> data)
        {
            if (data == null && data.Count == 0)
            {
                return 0;
            }
            int result = data.Where(x => x.Deaths.Total.HasValue).Select(x => x.Deaths.Total.Value).Sum();
            return result;
        }

        private static double CalculatePercentage(int total, int subset)
        {

            if (subset == 0)
            {
                return 0;
            }
            return ((double)subset / (double)total) * 100;

        }
        #endregion


    }

}