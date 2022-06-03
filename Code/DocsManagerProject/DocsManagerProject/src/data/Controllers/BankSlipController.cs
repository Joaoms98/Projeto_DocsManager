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
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(TB_BANK_SLIP))]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        [HttpPost]
        [Authorize(Roles = "USER, ADMIN")]
       public async Task<ActionResult> NewBankSlip([FromBody] NewBankSlipDTO bankSlip)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.NewBankSlip(bankSlip);
            return Created($"api/BankSlips", bankSlip);
        }

        public async Task<ActionResult> UpdateBankSlip([FromBody] UpdateBankSlipDTO bankSlip)
        {
            if (!ModelState.IsValid) return BadRequest();

            await _repository.UpdateBankSlip(bankSlip);
            return Ok(bankSlip);
        }

        public async Task<ActionResult> GetBankSlipById([FromRoute] int bankSlip)
        {
            var bankSlips = await _repository.GetBankSlipById(bankSlip);
            if (bankSlips == null) 
                return NotFound();
            return Ok(bankSlips);

        }

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
