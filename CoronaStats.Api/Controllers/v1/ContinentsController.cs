using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
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

        #region Members
        private readonly IMediator _mediator;
        #endregion

        #region ctor
        public ContinentsController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        #region Methods
        /// <summary>
        /// Gets the statistics by continent
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Core.Models.ContinentStatistics>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Core.Models.ContinentStatistics>> Get(string country = default)
        {
            return await _mediator.Send(new Domain.Continent.Queries.GetContinentStatisticsRequest(country)); 
        }
        #endregion

    }
}