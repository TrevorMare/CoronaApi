using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using CoronaStats.Core.Models;
using Microsoft.Extensions.Logging;

namespace CoronaStats.Business
{

    /// <summary>
    /// Business logic to retrieve the Api Data
    /// </summary>
    internal class RapidApiCovidStatistics : Interfaces.IRapidApiCovidStatistics
    {

        #region Members
        private readonly ILogger<RapidApiCovidStatistics> _logger;
        private readonly IHttpClientFactory _clientFactory;
        #endregion

        #region ctor
        public RapidApiCovidStatistics(ILogger<RapidApiCovidStatistics> logger,
                                IHttpClientFactory clientFactory)
        {
            this._logger = logger;
            this._clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }
        #endregion

        #region Interface Methods
        /// <summary>
        /// Loads the statisitics per continent
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public async Task<IEnumerable<ContinentStatistics>> GetContinentStatistics(string country = null)
        {
            var apiData = await LoadCovidApiStatistics(country);

            return Helpers.ContinentStatisticsBuilder.BuildStatistics(apiData.Response);
        }

        /// <summary>
        /// Loads the statisitics per country
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        public async Task<IEnumerable<CountryStatistics>> GetCountryStatistics(string country = null)
        {
            var apiData = await LoadCovidApiStatistics(country);

            return Helpers.CountryStatisticsBuilder.BuildStatistics(apiData.Response);
        }
        #endregion

        #region Methods

        /// <summary>
        /// Loads the data from the rapid Api host
        /// </summary>
        /// <param name="country"></param>
        /// <returns></returns>
        private async Task<Models.CovidApiModel> LoadCovidApiStatistics(string country = default)
        {
            try
            {
                Models.CovidApiModel result = null;

                _logger?.LogInformation($"Trying to fetch data from Rapid Api Covid Statistics");
                string requestPath = "statistics" + (string.IsNullOrEmpty(country) ? "" : $"?country={country}");

                var request = new HttpRequestMessage(HttpMethod.Get, requestPath);

                // Load the Http Client
                var client = GetRapidApiHttpClient();

                // Send request and retrieve response
                var response = await client.SendAsync(request);

                // If successfull
                if (response.IsSuccessStatusCode)
                {
                    var jsonContent = await response.Content.ReadAsStringAsync();
                    result = Newtonsoft.Json.JsonConvert.DeserializeObject<Models.CovidApiModel>(jsonContent);
                    
                    if (result.Errors != null && result.Errors.Length > 0)
                    {
                        throw new Exception($"An error occured during data retrieval {result.Errors}");
                    }
                }
                else
                {
                   throw new Exception($"An error occured reading the Rapid Api Content: Response code {response.StatusCode}");
                }
                // Return the result
                return result;

            }
            catch (Exception ex)
            {
                _logger?.LogError(ex.ToString());
                throw;
            }
        }

        private HttpClient GetRapidApiHttpClient()
        {

            var client = this._clientFactory.CreateClient(Common.Constants.RapidApiFactoryClientName);

            return client;
        }

       
        #endregion

    }

}