using Asp.Versioning;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Application.UseCases.Grupos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisApplication _paisAplication;

        public PaisController(IPaisApplication paisAplication)
        {
            _paisAplication = paisAplication;
        }

        #region Metodos Síncronos

        [HttpGet("GetPaises")]
        public IActionResult GetPaises()
        {
            var response = _paisAplication.GetPaises();
            

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Metodos Asíncronos

        [HttpGet("GetPaisesAsync")]
        public async Task<IActionResult> GetPaisesAsync()
        {
            var response = await _paisAplication.GetPaisesAsync();


            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

    }
}
