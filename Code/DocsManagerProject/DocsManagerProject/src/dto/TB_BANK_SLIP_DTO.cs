using DocsManagerProject.src.models;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocsManagerProject.src.dto
{
    /// <Sumary>
    /// <para>Resume> Creating DTO for insert new Bank Slip</para>
    /// <para>By: Vimirsi <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:17/05/2022</para>
    /// </summary>
    public class NewBankSlipDTO
    {        

        [Required]
        public TB_COMPANY Company { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public string Expiration_Date { get; set; }

        [Required]
        public string File_Address_Bank_Slip { get; set; }

        [Required]
        public string File_Address_Receipt { get; set; }

        public DateTime File_Date { get; set; }

        public NewBankSlipDTO(TB_COMPANY company, double value, string expiration_Date, string file_Address_Bank_Slip, string file_Address_Receipt, DateTime file_Date)
        {
            Company = company;
            Value = value;
            Expiration_Date = expiration_Date;
            File_Address_Bank_Slip = file_Address_Bank_Slip;
            File_Address_Receipt = file_Address_Receipt;
            File_Date = file_Date;
        }
    }

    /// <Sumary>
    /// <para>Resume> Creating DTO for update bank slip </para>
    /// <para>By: Vimirsi <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:17/05/2022</para>
    /// </summary>
    public class UpdateBankSlipDTO
    {

        [Required]
        public int Id_Bank_Slip { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public string Expiration_Date { get; set; }

        [Required]
        public string File_Address_Bank_Slip { get; set; }

        [Required]
        public string File_Address_Receipt { get; set; }

        public UpdateBankSlipDTO(int id_Bank_Slip, double value, string expiration_Date, string file_Address_Bank_Slip, string file_Address_Receipt)
        {
            Id_Bank_Slip = id_Bank_Slip;
            Value = value;
            Expiration_Date = expiration_Date;
            File_Address_Bank_Slip = file_Address_Bank_Slip;
            File_Address_Receipt= file_Address_Receipt;
        }
    }
}
