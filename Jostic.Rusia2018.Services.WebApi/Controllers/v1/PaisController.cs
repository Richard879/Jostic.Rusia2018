using Asp.Versioning;
using Jostic.Rusia2018.Application.Interface.UseCases;
using Jostic.Rusia2018.Application.UseCases.Grupos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("1.0")]
    public class PaisController : ControllerBase
    {
        private readonly IPaisApplication _paisAplication;

        public PaisController(IPaisApplication paisAplication)
        {
            _paisAplication = paisAplication;
        }

        #region Metodos Síncronos

        [HttpGet("GetPaisesAll")]
        public IActionResult GetPaisesAll()
        {
            var response = _paisAplication.GetPaisesAll();
            

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

        #region Metodos Asíncronos

        [HttpGet("GetPaisesAllAsync")]
        public async Task<IActionResult> GetPaisesAllAsync()
        {
            var response = await _paisAplication.GetPaisesAllAsync();


            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

    }
}
