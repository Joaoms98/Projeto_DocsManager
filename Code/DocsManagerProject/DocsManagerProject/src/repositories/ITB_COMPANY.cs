using DocsManagerProject.src.dto;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories
{
    /// <Sumary>
    /// <para>Resume> Creating Interface for Company </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:18/05/2022</para>
    /// </summary>
    public interface ITB_COMPANY
    {
        Task NewCompany(NewCompanyDTO newCompany);
        Task UpdateCompany(UpdateCompanyDTO updateCompany);
        Task<ITB_COMPANY> GetCompanyByCNPJ (string cnpj);
        Task<ITB_COMPANY>GetCompanyByTradeName (string tradeName);
    }
}
