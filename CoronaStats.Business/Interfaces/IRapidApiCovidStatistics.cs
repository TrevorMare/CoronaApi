using System.Collections.Generic;
using System.Threading.Tasks;

namespace CoronaStats.Business.Interfaces
{

    public interface IRapidApiCovidStatistics
    {

        Task<IEnumerable<Core.Models.ContinentStatistics>> GetContinentStatistics(string country = default);

        Task<IEnumerable<Core.Models.CountryStatistics>> GetCountryStatistics(string country = default);

    } 

}