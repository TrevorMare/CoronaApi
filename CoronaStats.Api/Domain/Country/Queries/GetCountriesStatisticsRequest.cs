using System.Collections.Generic;
using MediatR;

namespace CoronaStats.Api.Domain.Country.Queries
{

    public class GetCountriesStatisticsRequest : IRequest<IEnumerable<Core.Models.CountryStatistics>>
    {

        public string Country { get; private set; }

        public GetCountriesStatisticsRequest(string country)
        {
            this.Country = country;
        }


    }

}