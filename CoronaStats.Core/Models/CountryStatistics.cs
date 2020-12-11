using Newtonsoft.Json;

namespace CoronaStats.Core.Models
{

    public class CountryStatistics : ContinentStatistics
    {

        [JsonProperty(PropertyName = "country")]
        public string Country { get; set; }
        
    }

}