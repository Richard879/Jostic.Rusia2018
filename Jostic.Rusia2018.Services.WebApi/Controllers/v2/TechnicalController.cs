using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Technicals.Commands.CreateTechnicalCommand;
using Jostic.Rusia2018.Application.UseCases.Technicals.Commands.DeleteTechnicalCommand;
using Jostic.Rusia2018.Application.UseCases.Technicals.Commands.UpdateTechnicalCommand;
using Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetAllTechnicalQuery;
using Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetAllWithPaginationTechnicalQuery;
using Jostic.Rusia2018.Application.UseCases.Technicals.Queries.GetTechnicalQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class TechnicalController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TechnicalController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateTechnicalCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{idTecnico}")]
        public async Task<IActionResult> Update(int idTecnico, [FromBody] UpdateTechnicalCommand command)
        {
            var customerDto = await _mediator.Send(new GetTechnicalQuery() { idTecnico = idTecnico });
            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete{idTecnico}")]
        public async Task<IActionResult> Delete([FromRoute] int idTecnico)
        {
            if (idTecnico == 0)
                return BadRequest();
            var response = await _mediator.Send(new DeleteTechnicalCommand() { idTecnico = idTecnico });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{idTecnico}")]
        public async Task<IActionResult> Get(int idTecnico)
        {
            if (idTecnico == 0)
                return BadRequest();
            var response = await _mediator.Send(new GetTechnicalQuery() { idTecnico = idTecnico });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllTechnicalQuery());
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetAllWithPaginationTechnicalQuery() { PageNumber = pageNumber, PageSize = pageSize });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}