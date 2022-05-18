using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocsManagerProject.src.models
{
    /// <Sumary>
    /// <para>Resume> Creating atributes for TB_COMPANY </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:16/05/2022</para>
    /// </summary>
    [Table("TB_COMPANY")]
    public class TB_COMPANY
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id_Company { get; set; }

        [Required]
        public string Trade_Name { get; set; }
        
        [Required]
        public string CNPJ { get; set; }

        public string Telephone { get; set; }

        public string Agent { get; set; }
    }
}
