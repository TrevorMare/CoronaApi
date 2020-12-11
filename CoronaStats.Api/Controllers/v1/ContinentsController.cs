using Microsoft.AspNetCore.Mvc;

namespace CoronaStats.Api.Controllers.v1
{

    /// <summary>
    /// Api endpoint to retrieve Covid 19 Statistics by Continents
    /// </summary>
    [Route("api/v{v:apiVersion}/continents")]  
    [ApiVersion("1.0")]  
    [ApiController]
    public class ContinentsController : ControllerBase  
    {

        #region Methods
        /// <summary>
        /// Gets the statistics by continent
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v1 controller"); 
        }
        #endregion

    }
}