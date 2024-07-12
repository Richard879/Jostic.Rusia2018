using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Countrys.Commands.CreateCountryCommand;
using Jostic.Rusia2018.Application.UseCases.Countrys.Queries.GetAllQuery;
using Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllFilter;
using Jostic.Rusia2018.Application.UseCases.Countries.Queries.GetCountriesAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateCountryCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllCountryQuery());


            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetPaisesAll")]
        public async Task<IActionResult> GetPaisesAll()
        {
            var response = await _mediator.Send(new GetCountriesAllQuery());


            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetPaisesAllFilter")]
        public async Task<IActionResult> GetPaisesAllFilter([FromBody] GetCountryAllFilterQuery command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion
    }
}