﻿using Asp.Versioning;
using Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetAllQuery;
using Jostic.Rusia2018.Application.UseCases.Paises.Queries.GetPaisesAllQuery;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v3
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class PaisController : ControllerBase
    {
        private readonly IMediator _mediator;

        public PaisController(IMediator mediator)
        {
            _mediator = mediator;
        }

        #region Metodos Asíncronos

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            var response = await _mediator.Send(new GetAllPaisQuery());


            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        [HttpGet("GetPaisesAll")]
        public async Task<IActionResult> GetPaisesAll()
        {
            var response = await _mediator.Send(new GetPaisesAllQuery());


            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response.Message);
        }

        #endregion

    }
}
