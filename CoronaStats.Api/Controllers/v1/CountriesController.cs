using Microsoft.AspNetCore.Mvc;

namespace CoronaStats.Api.Controllers.v1
{

    [Route("api/v{v:apiVersion}/countries")]  
    [ApiVersion("1.0")]  
    [ApiController] 
    public class CountriesController : ControllerBase  
    {

        [HttpGet]
        public IActionResult Get()
        {
            return new OkObjectResult("employees from v1 controller"); 
        }

    }


}