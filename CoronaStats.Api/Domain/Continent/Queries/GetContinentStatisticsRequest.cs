using System.Collections.Generic;
using MediatR;

namespace CoronaStats.Api.Domain.Continent.Queries
{
    public class GetContinentStatisticsRequest : IRequest<IEnumerable<Core.Models.ContinentStatistics>>
    {

        public string Country { get; private set; }

        public GetContinentStatisticsRequest(string country)
        {
            this.Country = country;
        }


    }
}