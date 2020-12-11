namespace CoronaStats.Core.Config
{

    /// <summary>
    /// Class to map the Rapid Api configuration from the Configuration settings
    /// </summary>
    public class RapidApiConfig
    {

        #region Properties
        /// <summary>
        /// Gets or sets the key of RapidApi interface
        /// </summary>
        /// <value></value>
        public string Key { get; set; }

        /// <summary>
        /// Gets or sets the host of RapidApi interface
        /// </summary>
        /// <value></value>
        public string Host { get; set; }

        /// <summary>
        /// Gets or sets the Endpoint Url of RapidApi interface
        /// </summary>
        /// <value></value>
        public string Endpoint { get; set; }
        #endregion

    }

}