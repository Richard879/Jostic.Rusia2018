using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Phases.Commands.CreatePhaseCommand;
using Jostic.Rusia2018.Application.UseCases.Phases.Commands.DeletePhaseCommand;
using Jostic.Rusia2018.Application.UseCases.Phases.Commands.UpdatePhaseCommand;
using Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetAllPhaseQuery;
using Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetAllWithPaginationPhaseQuery;
using Jostic.Rusia2018.Application.UseCases.Phases.Queries.GetPhaseQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class PhaseController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PhaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreatePhaseCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{idFase}")]
        public async Task<IActionResult> Update(int idFase, [FromBody] UpdatePhaseCommand command)
        {
            var entityDto = await _mediator.Send(new GetPhaseQuery() { idFase = idFase });
            if (entityDto.Data == null)
                return NotFound(entityDto.Message);

            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete{idFase}")]
        public async Task<IActionResult> Delete([FromRoute] int idFase)
        {
            if (idFase == 0)
                return BadRequest();
            var response = await _mediator.Send(new DeletePhaseCommand() { idFase = idFase });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{idFase}")]
        public async Task<IActionResult> Get(int idFase)
        {
            if (idFase == 0)
                return BadRequest();
            var response = await _mediator.Send(new GetPhaseQuery() { idFase = idFase });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPhaseQuery());
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetAllWithPaginationPhaseQuery() { PageNumber = pageNumber, PageSize = pageSize });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}