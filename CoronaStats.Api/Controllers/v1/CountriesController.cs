using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace CoronaStats.Api.Controllers.v1
{

    [Route("api/v{v:apiVersion}/countries")]  
    [ApiVersion("1.0")]  
    [ApiController] 
    public class CountriesController : ControllerBase  
    {

        #region Members
        private readonly IMediator _mediator;
        #endregion

        #region ctor
        public CountriesController(IMediator mediator)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        }
        #endregion

        /// <summary>
        /// Gets the statistics by continent
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces("application/json")]
        [ProducesResponseType(typeof(IEnumerable<Core.Models.CountryStatistics>), (int)HttpStatusCode.OK)]
        public async Task<IEnumerable<Core.Models.CountryStatistics>> Get(string country = default)
        {
            return await _mediator.Send(new Domain.Country.Queries.GetCountriesStatisticsRequest(country)); 
        }

    }


}