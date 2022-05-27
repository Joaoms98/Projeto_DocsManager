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
    [Route("api/Companies")]
    [Produces("application/json")]
    public class CompanyController : ControllerBase
    {
        #region Attributes
        private readonly ITB_COMPANY _repository;
        #endregion

        #region Constructors
        public CompanyController(ITB_COMPANY repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new company
        /// </summary>
        /// <param name="company">NewCompanyDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Example:
        ///
        ///     POST /api/Users
        ///     {
        ///        "trade_name": "Trader Store LTDA",
        ///        "cnpj": "12345678901234",
        ///        "telephone": "11980807565",
        ///        "agent": "João Meneses"
        ///     } 
        ///
        /// </remarks>
        /// <response code="201">Returns created company</response>
        /// <response code="400">Requisition error</response>
        /// <response code="401">Company already created</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TB_COMPANY))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult> NewCompany([FromBody] NewCompanyDTO company)
        {
            //if (!ModelState.IsValid) return BadRequest();

            try
            {
                await _repository.CreateCompanyNotDuplicated(company);
                return Created($"api/Users", company);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult> UpdateCompany([FromBody] UpdateCompanyDTO company)
        {
            if (!ModelState.IsValid) return BadRequest();


            await _repository.UpdateCompany(company);
            return Ok(company);

        }

        /// <summary>
        /// Get Company By CNPJ
        /// </summary>
        /// <param cnpj="cnpj">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Returns company</response>
        /// <response code="404">CNPJ not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TB_USER))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult> GetCompanyByCNPJ([FromRoute] string cnpj)
        {
            var company = await _repository.GetCompanyByCNPJ(cnpj);

            if (company == null) return NotFound();
            return Ok(company);
        }

        /// <summary>
        /// Get Company By Trade Name
        /// </summary>
        /// <param trade_name="tradeName">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">Returns company</response>
        /// <response code="404">Trade Name not found</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TB_USER))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult> GetCompanyByTradeName([FromRoute] string tradeName)
        {
            var company = await _repository.GetCompanyByTradeName(tradeName);

            if (company == null) return NotFound();
            return Ok(company);
        }
        #endregion
    }
}