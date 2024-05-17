using Asp.Versioning;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Domain.Entity;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class GrupoController : ControllerBase
    {
        private readonly IGrupoApplication _grupoAplication;
        public GrupoController(IGrupoApplication grupoAplication)
        {
            _grupoAplication = grupoAplication;
        }

        #region Metodos Síncronos
        [HttpPost("Insert")]
        public IActionResult Insert([FromBody] GrupoDto grupoDTO)
        {
            if (grupoDTO == null)
                return BadRequest();
            var response = _grupoAplication.Insert(grupoDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpPut("Update/{idGrupo}")]
        public IActionResult Update(int idGrupo, [FromBody] GrupoDto grupoDTO)
        {
            var groupDTO = _grupoAplication.Get(idGrupo);
            if (groupDTO.Data == null)
                return NotFound(groupDTO.Message);

            if (grupoDTO == null)
                return BadRequest();
            var response = _grupoAplication.Update(grupoDTO);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpDelete("Delete{idGrupo}")]
        public IActionResult Delete(int idGrupo)
        {
            if (idGrupo == 0)
                return BadRequest();
            var response = _grupoAplication.Delete(idGrupo);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("Get{idGrupo}")]
        public IActionResult Get(int idGrupo)
        {
            if (idGrupo == 0)
                return BadRequest();
            var response = _grupoAplication.Get(idGrupo);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAll")]
        public IActionResult GetAll()
        {
            var response = _grupoAplication.GetAll();
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetAllWithPagination")]
        public IActionResult GetAllWithPagination([FromQuery] int pageNumber, int pageSize)
        {
            var response = _grupoAplication.GetAllWithPagination(pageNumber, pageSize);
            if (response.IsSucces)
                return Ok(response);

            return BadRequest(response.Message);
        }
        #endregion

    }
}
