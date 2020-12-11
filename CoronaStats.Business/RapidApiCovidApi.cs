using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;

namespace CoronaStats.Business
{

    /// <summary>
    /// Business logic to retrieve the Api Data
    /// </summary>
    public class RapidApiCovidApi : Interfaces.IRapidApiCovidApi
    {

        #region Members
        private readonly ILogger<RapidApiCovidApi> _logger;
        #endregion

        #region ctor
        public RapidApiCovidApi(ILogger<RapidApiCovidApi> logger)
        {
            this._logger = logger;
        }
        #endregion

        #region Interface Methods
       
        #endregion

    }

}