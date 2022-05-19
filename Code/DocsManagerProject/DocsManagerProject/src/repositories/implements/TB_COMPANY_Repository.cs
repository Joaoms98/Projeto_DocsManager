using DocsManagerProject.src.data;
using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DocsManagerProject.src.repositories.implements
{
    /// <summary>
    /// <para>Resume: Class responsible for implement interface</para>
    /// <para>By:Joaoms98</para>
    /// <para>Version: 1.0</para>
    /// <para>Date: 18/05/2022 </para>
    /// </summary>
    public class TB_COMPANY_Repository : ITB_COMPANY
    {
        #region attributes
        private readonly DocsManagerProjectContext _context;
        private readonly TB_COMPANY _company;
        #endregion

        #region contructors
        public TB_COMPANY_Repository (DocsManagerProjectContext context, TB_COMPANY company)
        {
            _context = context;
            _company = company;
        }
        #endregion

        #region methods
        /// <summary>
        /// <para>Resume: Method for finding one company by CNPJ</para>
        /// <para>By: Joaoms98</para>
        /// <para>Versão: 1.0</para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>
        public async Task<TB_COMPANY> GetCompanyByCNPJ(string cnpj)
        {
            return await _context.Companies
                    .FirstOrDefaultAsync(c => c.CNPJ == cnpj);
        }
        /// <summary>
        /// <para>Resume: Method for finding one company by TradeName</para>
        /// <para>By: Joaoms98</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 18/05/2022 </para>
        /// </summary>
        public async Task<TB_COMPANY> GetCompanyByTradeName(string tradeName)
        {
            return await _context.Companies
                   .FirstOrDefaultAsync(c => c.Trade_Name == tradeName);
        }
        /// <summary>
        /// <para>Resume: Method for add new company </para>
        /// <para>By: Joaoms98</para>
        /// <para>Version: 1.0</para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>
        public async Task NewCompany(NewCompanyDTO Company)
        {
            await _context.Companies.AddAsync(new TB_COMPANY
            {
                Trade_Name = Company.Trade_Name,
                CNPJ = Company.CNPJ,
                Telephone = Company.Telephone,
                Agent = Company.Agent
            });
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resume: Method for update Company </para>
        /// <para>By: Joaoms98</para>
        /// <para>Version: 1.0</para>
        /// <para>Date: 18/05/2022 </para>
        /// </summary>
        public async Task UpdateCompany(UpdateCompanyDTO company)
        {
            var _company  = await GetCompanyByCNPJ(company.CNPJ);
            _company.Trade_Name = company.Trade_Name;
            _company.CNPJ = company.CNPJ;
            _company.Telephone = company.Telephone;
            _company.Agent = company.Agent;
            _context.Companies.Update(_company);
            await _context.SaveChangesAsync();
        }
        #endregion
    }
}
