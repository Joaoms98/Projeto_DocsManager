using DocsManagerProject.src.models;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories
{
    public interface ITB_USER
    {
        Task<TB_USER> GetUserByEmail(string email);
    }
}
