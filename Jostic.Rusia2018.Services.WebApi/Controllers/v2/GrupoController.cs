using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Grupos.Commands.CreateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Grupos.Commands.DeleteGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Grupos.Commands.UpdateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetAllGrupoQuery;
using Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetAllWithPaginationGrupoQuery;
using Jostic.Rusia2018.Application.UseCases.Grupos.Queries.GetGrupoQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.RateLimiting;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v3
{
    [EnableRateLimiting("fixedWindow")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("2.0")]
    public class GrupoController : ControllerBase
    {

        private readonly IMediator _mediator;

        public GrupoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateGrupoCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{idGrupo}")]
        public async Task<IActionResult> Update(int idGrupo, [FromBody] UpdateGrupoCommand command)
        {
            var customerDto = await _mediator.Send(new GetGrupoQuery() { idGrupo = idGrupo});
            if (customerDto.Data == null)
                return NotFound(customerDto.Message);

            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete{idGrupo}")]
        public async Task<IActionResult> Delete([FromRoute]  int idGrupo)
        {
            if (idGrupo == 0)
                return BadRequest();
            var response = await _mediator.Send(new DeleteGrupoCommand() { idGrupo = idGrupo });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{idGrupo}")]
        public async Task<IActionResult> Get(int idGrupo)
        {
            if (idGrupo == 0)
                return BadRequest();
            var response = await _mediator.Send(new GetGrupoQuery() { idGrupo = idGrupo });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllGrupoQuery());
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetAllWithPaginationGrupoQuery() { PageNumber = pageNumber, PageSize = pageSize } );
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}