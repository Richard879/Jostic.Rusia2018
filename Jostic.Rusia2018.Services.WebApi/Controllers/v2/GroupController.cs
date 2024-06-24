using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Groups.Commands.CreateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Groups.Commands.DeleteGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Groups.Commands.UpdateGrupoCommand;
using Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetAllGrupoQuery;
using Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetAllWithPaginationGrupoQuery;
using Jostic.Rusia2018.Application.UseCases.Groups.Queries.GetGrupoQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class GroupController : ControllerBase
    {
        private readonly IMediator _mediator;

        public GroupController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [HttpPost("Insert")]
        public async Task<IActionResult> Insert([FromBody] CreateGroupCommand command)
        {
            if (command == null)
                return BadRequest();
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{idGrupo}")]
        public async Task<IActionResult> Update(int idGrupo, [FromBody] UpdateGroupCommand command)
        {
            var customerDto = await _mediator.Send(new GetGroupQuery() { idGrupo = idGrupo });
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
        public async Task<IActionResult> Delete([FromRoute] int idGrupo)
        {
            if (idGrupo == 0)
                return BadRequest();
            var response = await _mediator.Send(new DeleteGroupCommand() { idGrupo = idGrupo });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get/{idGrupo}")]
        public async Task<IActionResult> Get(int idGrupo)
        {
            if (idGrupo == 0)
                return BadRequest();
            var response = await _mediator.Send(new GetGroupQuery() { idGrupo = idGrupo });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllGroupQuery());
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public async Task<IActionResult> GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = await _mediator.Send(new GetAllWithPaginationGroupQuery() { PageNumber = pageNumber, PageSize = pageSize });
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion
    }
}