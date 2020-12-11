using System;
using Newtonsoft.Json;

namespace CoronaStats.Business.Models
{
    internal class CovidApiResponse
    {

        #region Properties

        [JsonProperty(PropertyName = "continent")]
        public string Continent { get; set; }

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }

        [JsonProperty(PropertyName = "population")]
        public int? Population { get; set; }

        [JsonProperty(PropertyName = "cases")]
        public CovidApiCases Cases { get; set; }

        [JsonProperty(PropertyName = "deaths")]
        public CovidApiDeaths Deaths { get; set; }

        [JsonProperty(PropertyName = "tests")]
        public CovidApiTests Tests { get; set; }

        [JsonProperty(PropertyName = "day")]
        public string Day { get; set; }

        [JsonProperty(PropertyName = "time")]
        public DateTime Time { get; set; }

        #endregion

    }
}