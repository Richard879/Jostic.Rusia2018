using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Continentes.Queries.GetContinentQuery;
using Jostic.Rusia2018.Application.UseCases.Continents.Commands.CreateContinentCommand;
using Jostic.Rusia2018.Application.UseCases.Continents.Commands.DeleteContinentCommand;
using Jostic.Rusia2018.Application.UseCases.Continents.Commands.UpdateContinentCommand;
using Jostic.Rusia2018.Application.UseCases.Continents.Queries.GetAllGrupoQuery;
using Jostic.Rusia2018.Application.UseCases.Continents.Queries.GetAllWithPaginationContinentQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class ContinentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ContinentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateContinentCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{idContinente}")]
        public async Task<IActionResult> Update(int idContinente, [FromBody] UpdateContinentCommand command)
        {
            var customerDto = await _mediator.Send(new GetContinentQuery() { idContinente = idContinente });
            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete{idContinente}")]
        public async Task<IActionResult> Delete([FromRoute] int idContinente)
        {
            if (idContinente == 0)
                return BadRequest();
            var response = await _mediator.Send(new DeleteContinentCommand() { idContinente = idContinente });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{idContinente}")]
        public async Task<IActionResult> Get(int idContinente)
        {
            if (idContinente == 0)
                return BadRequest();
            var response = await _mediator.Send(new GetContinentQuery() { idContinente = idContinente });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllContinentQuery());
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetAllWithPaginationContinentQuery() { PageNumber = pageNumber, PageSize = pageSize });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}