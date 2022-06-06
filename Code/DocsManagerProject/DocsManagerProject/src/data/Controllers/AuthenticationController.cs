using DocsManagerProject.src.dto;
using DocsManagerProject.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DocsManagerProject.src.data.Controllers
{
    [ApiController]
    [Route("api/Authentication")]
    [Produces("application/json")]
    public class AuthenticationController : ControllerBase
    {
        #region Attributes

        private readonly IAuthentication _services;

        #endregion

        #region Constructor

        public AuthenticationController(IAuthentication services)
        {
            _services = services;
        }

        #endregion

        #region Methods
        /// <summary>
        /// Get authenticate
        /// </summary>
        /// <param name="authentication">AuthenticateDTO</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">create token</response>
        /// <response code="401">username not found or password incorrect</response>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult> AuthenticationAsync([FromBody] AuthenticateDTO authentication)
        {
            if (!ModelState.IsValid) return BadRequest();
            try
            {
                var authorization = await _services.GetAuthorization(authentication);
                return Ok(authorization);
            }
            catch (Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        #endregion
    }
}
