
using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoronaStats.Business.Models
{
    internal class CovidApiModel
    {
        [JsonProperty(PropertyName = "get")]
        public string Get { get; set; }
        
        [JsonProperty(PropertyName = "parameters")]
        public object[] Parameters { get; set; }

        [JsonProperty(PropertyName = "errors")]
        public object[] Errors { get; set; }

        [JsonProperty(PropertyName = "results")]
        public int NumberOfResults { get; set; }

        [JsonProperty(PropertyName = "response")]
        public List<CovidApiResponse> Response { get; set; }

    }
}


