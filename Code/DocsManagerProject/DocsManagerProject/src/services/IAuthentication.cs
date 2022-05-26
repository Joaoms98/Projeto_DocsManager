using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using System.Threading.Tasks;

namespace DocsManagerProject.src.services
{
    /// <summary>
    /// <para>Created Interface IAuthentication</para>
    /// <para>By: Joaoms98</para>
    /// <para>v 1.0</para>
    /// <para>25/05/2022</para>
    /// </summary>
    public interface IAuthentication
    {
        string EncodePassword(string password);
        Task CreateUserNotDuplicated(NewUserDTO user);
        string GenerateToken(TB_USER user);
        Task<AuthorizationDTO> GetAuthorization(AuthenticateDTO authentication);
    }
}
