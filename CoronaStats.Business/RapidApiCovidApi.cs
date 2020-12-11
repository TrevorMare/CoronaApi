using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoronaStats.Business
{

    /// <summary>
    /// Business logic to retrieve the Api Data
    /// </summary>
    internal class RapidApiCovidApi : Interfaces.IRapidApiCovidApi
    {

        #region Members
        private readonly ILogger<RapidApiCovidApi> _logger;
        private readonly IHttpClientFactory _clientFactory;
        #endregion

        #region ctor
        public RapidApiCovidApi(ILogger<RapidApiCovidApi> logger,
                                IHttpClientFactory clientFactory)
        {
            this._logger = logger;
            this._clientFactory = clientFactory ?? throw new ArgumentNullException(nameof(clientFactory));
        }
        #endregion

        #region Interface Methods
       
        #endregion

        #region Methods
        private HttpClient GetRapidApiHttpClient()
        {

            var client = this._clientFactory.CreateClient(Common.Constants.RapidApiFactoryClientName);

            return client;
        }
        #endregion

    }

}