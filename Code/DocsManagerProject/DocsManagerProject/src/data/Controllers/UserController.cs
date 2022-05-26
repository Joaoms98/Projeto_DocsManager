using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using DocsManagerProject.src.repositories;
using DocsManagerProject.src.services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace DocsManagerProject.src.data.Controllers
{
    [ApiController]
    [Route("api/Users")]
    [Produces("apllication/json")]
    public class UserController : ControllerBase
    {
        #region Attributes
        private readonly ITB_USER _repository;
        private readonly IAuthentication _services;
        #endregion

        #region Constructors
        public UserController(ITB_USER repository,IAuthentication services)
        {
            _repository = repository;
            _services = services;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new user
        /// </summary>
        /// <param name="user">NewUserDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Example:
        ///
        ///     POST /api/Users
        ///     {
        ///        "email": "jvm1800@gmail.com",
        ///        "password": "134652",
        ///        "type": "ADMIN"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Returns created user</response>
        /// <response code="400">Requisition error</response>
        /// <response code="401">Email already signed in</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TB_USER))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [Authorize]
        [AllowAnonymous]
        public async Task<ActionResult> NewUser([FromBody] NewUserDTO user)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _services.CreateUserNotDuplicated(user);
                return Created($"api/Users", user);
            }
            catch(Exception ex)
            {
                return Unauthorized(ex.Message);
            }
        }

        /// <summary>
        /// Get User By Address
        /// </summary>
        /// <param name="email">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Returns user</response>
        /// <response code="404">Email not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TB_USER))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("email/{useremail}")]
        [Authorize(Roles = "USER, ONG, ADMIN")]
        public async Task<ActionResult> GetUserByAdressAsync([FromRoute] string email)
        {
            var user = await _repository.GetUserByEmail(email);

            if (user == null) return NotFound();
            return Ok(user);
        }

        #endregion
    }   
}



