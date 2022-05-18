using DocsManagerProject.src.dto;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories
{
    public interface ITB_BANK_SLIP
    {
        Task NewBankSlip(NewBankSlipDTO newBankSlip);

        Task UpdateBankSlip(UpdateBankSlipDTO updateBankSlip);

        Task<List<ITB_BANK_SLIP>> GetBankSlipBySearch(double value, string expirationDate, DateTime fileData);
    }
}
