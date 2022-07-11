using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using DocsManagerProject.src.repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocsManagerProject.src.data.Controllers
{
    /// <summary>
    /// <para>Resume: Controller created</para>
    /// <para>By: Higlik </para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 26/05/2022 </para>
    /// </summary>

    [ApiController]
    [Route("api/BankSlips")]
    [Produces("aplication/json")]

    public class BankSlipController : ControllerBase
    {
        #region Attributes
        private readonly ITB_BANK_SLIP _repository;
        #endregion

        #region Constructors
        public BankSlipController(ITB_BANK_SLIP repository)
        {
            _repository = repository;
        }
        #endregion

        #region Methods
        /// <summary>
        /// Create a new Bankslips
        /// </summary>
        /// <param name="bankSlip">NewBankSlipDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Example:
        ///
        ///     POST /api/BankSlips
        ///     {
        ///        "company": "Trader Store LTDA",
        ///        "value": 12.54,
        ///        "Expiration_Date": "11/05/2021",
        ///        "File_Address_Bank_Slip": "file adress"
        ///        "File_Address_Receipt": "file adress"
        ///        "File_Date": 10/15/2021
        ///     } 
        ///     
        /// </remarks>
        /// <response code="201">Returns created company</response>
        /// <response code="400">Requisition error</response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TB_BANK_SLIP))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPost]
        [Authorize(Roles = "USER, ADMIN")]
       public async Task<ActionResult> NewBankSlip([FromBody] NewBankSlipDTO bankSlip)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewBankSlip(bankSlip);
            return Created($"api/BankSlips", bankSlip);
        }

        /// <summary>
        /// Update User
        /// </summary>
        /// <param name="bankSlip">UpdateBankSlipDTO</param>
        /// <returns>ActionResult</returns>
        /// <remarks>
        /// Example:
        ///
        ///     PUT /api/BankSlips
        ///     {
        ///        "id": 1,    
        ///        "value": 12.54,
        ///        "Expiration_Date": "11/05/2021",
        ///        "File_Address_Bank_Slip": "file adress"
        ///        "File_Address_Receipt": "file adress"
        ///     }
        ///
        /// </remarks>
        /// <response code="201">Úpdate bankslip </response>
        /// <response code="400"> not found/badrequest </response>
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TB_BANK_SLIP))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpPut]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult> UpdateBankSlip([FromBody] UpdateBankSlipDTO bankSlip)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateBankSlip(bankSlip);
            return Ok(bankSlip);
        }

        /// <summary>
        ///  Get BankSlip by id
        /// </summary>
        /// <param name="bankSlip">int</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">return ok </response>
        /// <response code="404">bankslip not existing</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TB_BANK_SLIP))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("BankSlips/{idBankSlips}")]
        [Authorize(Roles = "USER, ADMIN")]
        public async Task<ActionResult> GetBankSlipById([FromRoute] int idBankSlips)
        {
            var bankSlips = await _repository.GetBankSlipById(idBankSlips);
            if (bankSlips == null) 
                return NotFound();
            return Ok(bankSlips);
        }

        /// <summary>
        ///  Get All BankSlip by Search
        /// </summary>
        /// <param name="value">double</param>
        /// <param name="expirationDate">string</param>
        /// <param name="cnpj">string</param>
        /// <returns>ActionResult</returns>
        /// <response code="200">return ok </response>
        /// <response code="404">bankslip does not exist</response>
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(TB_BANK_SLIP))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [HttpGet("search")]
        [Authorize]
        public async Task<ActionResult> GetBankSlipBySearch([FromQuery]double value, string expirationDate, string cnpj)
        {
            var list = await _repository.GetBankSlipBySearch(value, expirationDate, cnpj);
           if (list == null) 
                return NoContent();
           return Ok(list);
        }
        #endregion
    }
}
