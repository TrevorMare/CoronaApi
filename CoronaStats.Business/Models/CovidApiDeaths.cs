
using Newtonsoft.Json;

namespace CoronaStats.Business.Models
{
    internal class CovidApiDeaths
    {

        #region Properties

        [JsonProperty(PropertyName = "_new")]
        public string New { get; set; }

        [JsonProperty(PropertyName = "_1M_pop")]
        public string OneMillionPop { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        #endregion

    }
}


