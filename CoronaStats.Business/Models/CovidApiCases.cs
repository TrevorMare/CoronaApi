
using Newtonsoft.Json;

namespace CoronaStats.Business.Models
{
    internal class CovidApiCases
    {

        #region Properties

        [JsonProperty(PropertyName = "new")]
        public string New { get; set; }

        [JsonProperty(PropertyName = "active")]
        public int? Active { get; set; }

        [JsonProperty(PropertyName = "critical")]
        public int? Critical { get; set; }

        [JsonProperty(PropertyName = "recovered")]
        public int? Recovered { get; set; }

        [JsonProperty(PropertyName = "1M_pop")]
        public string OneMillionPop { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        #endregion

    }
}


