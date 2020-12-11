using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace CoronaStats.Api.Domain.Continent.Queries
{
    public class GetContinentStatisticsHandler : IRequestHandler<GetContinentStatisticsRequest, IEnumerable<Core.Models.ContinentStatistics>>
    {

        #region Members
        private readonly Business.Interfaces.IRapidApiCovidStatistics _covidApi;
        #endregion

        #region ctor
        public GetContinentStatisticsHandler(Business.Interfaces.IRapidApiCovidStatistics covidApi)
        {
            _covidApi = covidApi ?? throw new ArgumentNullException(nameof(covidApi));
        }
        #endregion

        #region Method Handlers
        public async Task<IEnumerable<Core.Models.ContinentStatistics>> Handle(GetContinentStatisticsRequest request, CancellationToken cancellationToken)
        {
            // Load the country statistics
            return await _covidApi.GetContinentStatistics(request.Country);        
        }
        #endregion

    }
}