using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using CoronaStats.Core.Models;
using MediatR;

namespace CoronaStats.Api.Domain.Country.Queries
{
    public class GetCountriesStatisticsHandler : IRequestHandler<GetCountriesStatisticsRequest, IEnumerable<Core.Models.CountryStatistics>>
    {

        #region Members
        private readonly Business.Interfaces.IRapidApiCovidApi _covidApi;
        #endregion

        #region ctor
        public GetCountriesStatisticsHandler(Business.Interfaces.IRapidApiCovidApi covidApi)
        {
            _covidApi = covidApi ?? throw new ArgumentNullException(nameof(covidApi));
        }
        #endregion

        #region Method Handlers
        public async Task<IEnumerable<CountryStatistics>> Handle(GetCountriesStatisticsRequest request, CancellationToken cancellationToken)
        {
            // Load the country statistics
            return await _covidApi.GetCountryStatistics(request.Country);        
        }
        #endregion

    }
}