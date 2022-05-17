using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocsManagerProject.src.models
{
    /// <Sumary>
    /// <para>Resume> Creating atributes for table TB_BANK_SLIP </para>
    /// <para>By: Higlik <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:16/05/2022</para>
    /// </summary>
    
    [Table("TB_BANK_SLIP")]
    public class TB_BANK_SLIP
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Bank_Slip { get; set; }

        [Required]
        public double Value { get; set; }

        [Required]
        public string Expiration_Date { get; set; }

        [Required]
        public string File_Address { get; set; }
    }
}
