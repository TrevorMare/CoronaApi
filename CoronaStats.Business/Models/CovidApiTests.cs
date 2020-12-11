
using Newtonsoft.Json;

namespace CoronaStats.Business.Models
{
    internal class CovidApiTests
    {

        #region Properties

        [JsonProperty(PropertyName = "_1M_pop")]
        public string OneMillionPop { get; set; }

        [JsonProperty(PropertyName = "total")]
        public int? Total { get; set; }

        #endregion

    }
}


