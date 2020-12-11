using Newtonsoft.Json;

namespace CoronaStats.Core.Models
{

    public class CategoryStatistics
    {
        [JsonProperty(PropertyName = "total")]
        public int Total { get; set; }

        [JsonProperty(PropertyName = "percent")]
        public int Percent { get; set; }
    }

}