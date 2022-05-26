using DocsManagerProject.src.utilities;
using System.ComponentModel.DataAnnotations;

namespace DocsManagerProject.src.dto
{
    /// <Sumary>
    /// <para>Resume> Creating DTO for insert new User </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:25/05/2022</para>
    /// </summary>
    public class NewUserDTO
    {
        [Key]
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [Required]
        public UserType Type { get; set; }

        public NewUserDTO (string email, string password, UserType type)
        {
            Email = email;
            Password = password;
            Type = type;
        }
    }
}

 