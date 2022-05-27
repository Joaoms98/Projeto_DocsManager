using DocsManagerProject.src.dto;
using DocsManagerProject.src.repositories;
using Microsoft.AspNetCore.Authorization;
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
