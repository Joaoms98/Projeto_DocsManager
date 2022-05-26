using DocsManagerProject.src.data;
using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories.implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement Bank Slip interface</para>
    /// <para>By: Vimirsi </para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 18/05/2022 </para>
    /// </summary>
    public class TB_BANK_SLIP_Repository : ITB_BANK_SLIP
    {

        #region attributes
        private readonly DocsManagerProjectContext _context;
        #endregion

        #region constructors
        public TB_BANK_SLIP_Repository (DocsManagerProjectContext context)
        {
            _context = context;
        }
        #endregion

        #region methods
        /// <summary>
        /// <para>Resume: Method for finding one company by Search</para>
        /// <para>By: Vimirsi </para>
        /// <para>Version: 1.0</para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>

        public async Task<List<TB_BANK_SLIP>> GetBankSlipBySearch(double value, string expirationDate, string cnpj)
        {
            switch(value, expirationDate, cnpj) 
            {
                case (_, null, null):
                    return await _context.BankSlips
                        .Where(b => b.Value == value)
                        .ToListAsync();
                case (0.0, _, null):
                    return await _context.BankSlips
                        .Where(b => b.Expiration_Date == expirationDate)
                        .ToListAsync();
                case (0.0, null, _):
                    return await _context.BankSlips
                        .Where(b => b.Company.CNPJ == cnpj)
                        .ToListAsync();
                case (_, _, null):
                    return await _context.BankSlips
                        .Where(b => b.Expiration_Date.Contains(expirationDate) & b.Value == value)
                        .ToListAsync();
                case (0.0, _, _):
                    return await _context.BankSlips
                        .Where(b => b.Expiration_Date.Contains(expirationDate) & b.Company.CNPJ == cnpj)
                        .ToListAsync();
                case (_, _, _):
                    return await _context.BankSlips
                    .Where(b => b.Expiration_Date.Contains(expirationDate) & b.Company.CNPJ == cnpj & b.Value == value)
                    .ToListAsync();
            }
        }

        /// <summary>
        /// <para>Resume: Method responsible for searching a Bank Slip by id</para>
        /// <para>By: Vimirsi </para>
        /// <para>Version: 1.0</para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>
        public async Task<TB_BANK_SLIP> GetBankSlipById(int idBankSlip)
        {
            return await _context.BankSlips
                .FirstOrDefaultAsync(b => b.Id_Bank_Slip == idBankSlip);
        }
        /// <summary>
        /// <para>Resume: Method responsible for adding a new Bank Slip</para>
        /// <para>By: Vimirsi </para>
        /// <para>Version: 1.0</para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>

        public async Task NewBankSlip(NewBankSlipDTO bankSlip)
        {
            await _context.BankSlips.AddAsync(new TB_BANK_SLIP
            {
                Company = bankSlip.Company,
                Value = bankSlip.Value,
                Expiration_Date = bankSlip.Expiration_Date,
                File_Address_Bank_Slip = bankSlip.File_Address_Bank_Slip,
                File_Address_Receipt = bankSlip.File_Address_Receipt,
                File_Date = bankSlip.File_Date
            });
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resume: Method used for updating an existing Bank Slip</para>
        /// <para>By: Vimirsi </para>
        /// <para>Version: 1.0 </para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>
        public async Task UpdateBankSlip(UpdateBankSlipDTO bankSlip)
        {
            var _bankslip = await GetBankSlipById(bankSlip.Id_Bank_Slip);
            _bankslip.Value = bankSlip.Value;
            _bankslip.Expiration_Date = bankSlip.Expiration_Date;
            _bankslip.File_Address_Bank_Slip = bankSlip.File_Address_Bank_Slip;
            _bankslip.File_Address_Receipt = bankSlip.File_Address_Receipt;
            _bankslip.File_Date = bankSlip.File_Date;
            _context.BankSlips.Update(_bankslip);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
