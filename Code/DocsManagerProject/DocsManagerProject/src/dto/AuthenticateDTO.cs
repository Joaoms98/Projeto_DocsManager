using DocsManagerProject.src.utilities;
using System.ComponentModel.DataAnnotations;

namespace DocsManagerProject.src.dto
{
    /// <Sumary>
    /// <para>Resume> Creating DTO for Authenticate </para>
    /// <para>By: Vimirsi <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:17/05/2022</para>
    /// </summary>
    public class AuthenticateDTO
    {
        [Required]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        public AuthenticateDTO(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }

    /// <Sumary>
    /// <para>Resume> Creating DTO for Authorization </para>
    /// <para>By: Vimirsi <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:17/05/2022</para>
    /// </summary>
    public class AuthorizationDTO
    {
        public string Email { get; set; }
        public UserType Type { get; set; }
        public string Token { get; set; }

        public AuthorizationDTO(string email, UserType type, string token)
        {
            Email = email;
            Type = type;
            Token = token;
        }
    }
}

