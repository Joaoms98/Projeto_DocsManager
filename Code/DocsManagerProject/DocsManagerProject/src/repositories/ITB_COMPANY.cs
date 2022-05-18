using DocsManagerProject.src.dto;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories
{
    public interface ITB_COMPANY
    {
        Task NewCompany(NewCompanyDTO newCompany);
        Task UpdateCompany(UpdateCompanyDTO updateCompany);
        Task<ITB_COMPANY> GetCompanyByCNPJ (string cnpj);
        Task<ITB_COMPANY>GetCompanyByTradeName (string tradeName);
    }
}
