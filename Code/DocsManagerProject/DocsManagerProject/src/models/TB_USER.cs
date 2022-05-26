using DocsManagerProject.src.utilities;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DocsManagerProject.src.models
{
    /// <Sumary>
    /// <para>Resume> Creating atributes for TB_USERS </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:16/05/2022</para>
    /// </summary>
    [Table("TB_USER")]
    public class TB_USER
    {
       [Key]
       [Required]
       public string Email { get; set; }
       
       [Required]
       public string Password { get; set; }
       
       [Required]
       public UserType Type { get; set; }
    }
}
