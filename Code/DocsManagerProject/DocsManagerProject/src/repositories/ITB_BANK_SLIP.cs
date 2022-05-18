using DocsManagerProject.src.dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories
{
    /// <Sumary>
    /// <para>Resume> Creating Interface for Bank Slip </para>
    /// <para>By: Higlik <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:18/05/2022</para>
    /// </summary>
    public interface ITB_BANK_SLIP
    {
        Task NewBankSlip(NewBankSlipDTO newBankSlip);

        Task UpdateBankSlip(UpdateBankSlipDTO updateBankSlip);

        Task<List<ITB_BANK_SLIP>> GetBankSlipBySearch(double value, string expirationDate, DateTime fileData);
    }
}
