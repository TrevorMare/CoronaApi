using Newtonsoft.Json;

namespace CoronaStats.Core.Models
{

    public class ContinentStatistics
    {
        
        [JsonProperty(PropertyName = "continent")]
        public string Continent { get; set; }

        [JsonProperty(PropertyName = "new")]
        public CategoryStatistics NewStatistics { get; set; }

        [JsonProperty(PropertyName = "active")]
        public CategoryStatistics ActiveStatistics { get; set; }


        [JsonProperty(PropertyName = "deaths")]
        public CategoryStatistics DeathStatistics { get; set; }
        
    }

}