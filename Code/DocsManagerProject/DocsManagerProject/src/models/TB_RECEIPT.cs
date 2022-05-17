using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocsManagerProject.src.models
{
    /// <Sumary>
    /// <para>Resume> Creating atributes for TB_RECEIPT </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:16/05/2022</para>
    /// </summary>
    [Table("TB_RECEIPT")]
    public class TB_RECEIPT
    {
        [ForeignKey("PFK_TB_RECEIPT")]
        public TB_BANK_SLIP Id_Bank_Slip { get; set; }

        [Required]
        public string Rc_FileAddress { get; set; }
    }
}
