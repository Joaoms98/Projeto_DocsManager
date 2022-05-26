
using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories
{
    /// <Sumary>
    /// <para>Resume> Creating Interface for User </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:18/05/2022</para>
    /// </summary>
    public interface ITB_USER
    {
        Task NewUser(NewUserDTO user);
        Task<TB_USER> GetUserByEmail(string email);
    }
}
