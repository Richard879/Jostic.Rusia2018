using Asp.Versioning;
using Jostic.Rusia2018.Application.DTO;
using Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserRefreshTokenCommand;
using Jostic.Rusia2018.Application.UseCases.Users.Commands.CreateUserTokenCommand;
using Jostic.Rusia2018.Domain.Entity;
using Jostic.Rusia2018.Services.WebApi.Helpers;
using Jostic.Rusia2018.Transversal.Common;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Jostic.Rusia2018.Services.WebApi.Controllers.v2
{
    [Authorize]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class UserController : ControllerBase
    {
        private readonly AppSettings _appSettings;
        private readonly IMediator _mediator;

        public UserController(IOptions<AppSettings> appSettings, IMediator mediator)
        {
            _appSettings = appSettings.Value;
            _mediator = mediator;
        }

        #region Metodos Asíncronos
        [AllowAnonymous]
        [HttpPost("Authenticate")]
        public async Task<IActionResult> Authenticate([FromBody] CreateUserTokenCommand command)
        {
            var response = await _mediator.Send(command);
            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            return BadRequest(response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken()
        {
            var identity = User.Identity as ClaimsIdentity;
            IEnumerable<Claim> claims = identity.Claims;
            var UserId = claims.Where(p => p.Type == ClaimTypes.Name).FirstOrDefault()?.Value;

            var response = await _mediator.Send(new CreateUserRefreshTokenQuery { UserId = Convert.ToInt32(UserId) });

            if (response == null)
                return Unauthorized(new { message = "Invalid token" });

            if (response.IsSuccess)
            {
                if (response.Data != null)
                {
                    response.Data.Token = BuildToken(response);
                    response.Data.refresh_token = BuildToken(response, true);
                    response.Data.inactivityExpiration = _appSettings.ExpiredTimeToken;
                    return Ok(response);
                }
                else
                {
                    return NotFound(response);
                }
            }
            return BadRequest(response);
        }

        private string BuildToken(Response<UserDto> userDto, bool isRefresh = false)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, userDto.Data!.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddMinutes((!isRefresh) ? Int32.Parse(_appSettings.ExpiredTimeToken) : Int32.Parse(_appSettings.ExpiredTimeRefreshToken)),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _appSettings.Issuer,
                Audience = _appSettings.Audience
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var tokenString = tokenHandler.WriteToken(token);
            return tokenString;
        }
        #endregion
    }
}