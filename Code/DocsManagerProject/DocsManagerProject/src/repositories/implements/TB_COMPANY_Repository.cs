using DocsManagerProject.src.data;
using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using Microsoft.EntityFrameworkCore;
using System;
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
        #endregion

        #region contructors
        public TB_COMPANY_Repository (DocsManagerProjectContext context)
        {
            _context = context;
        }
        #endregion

        #region methods
        /// <summary>
        /// <para>Resume: Asynchronous methods to get a company by cnpj</para>
        /// </summary>
        /// <param name="cnpj">cnpj by company</param>
        /// <return>TB_COMPANY</return>
        public async Task<TB_COMPANY> GetCompanyByCNPJ(string cnpj)
        {
            return await _context.Companies
                    .FirstOrDefaultAsync(c => c.CNPJ == cnpj);
        }
        /// <summary>
        /// <para>Resume: Asynchronous methods to get a company by name</para>
        /// </summary>
        /// <param name="tradeName">name by company</param>
        /// <return>TB_COMPANY</return>
        public async Task<TB_COMPANY> GetCompanyByTradeName(string tradeName)
        {
            return await _context.Companies
                   .FirstOrDefaultAsync(c => c.Trade_Name == tradeName);
        }
        /// <summary>
        /// <para>Resume: Asynchronous methods to created a new Company</para>
        /// </summary>
        /// <param name="company">NewCompanyDTO</param>
        public async Task NewCompany(NewCompanyDTO company)
        {
            await _context.Companies.AddAsync(new TB_COMPANY
            {
                Trade_Name = company.Trade_Name,
                CNPJ = company.CNPJ,
                Telephone = company.Telephone,
                Agent = company.Agent
            });
            await _context.SaveChangesAsync();
        }
        /// <summary>
        /// <para>Resume: Asynchronous methods to update a company</para>
        /// </summary>
        /// <param name="company">UpdateCompanyDTO</param>
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

        /// <summary>
        /// <para>Resumo: Asynchronous method responsible for creating company without duplicating in the database</para>
        /// </summary>
        /// <param name="dto">NewCompanyDTO</param>
        public async Task CreateCompanyNotDuplicated(NewCompanyDTO dto)
        {
            var company = await GetCompanyByCNPJ(dto.CNPJ);
            if (company != null) throw new Exception("This company already exist");
            await NewCompany(dto);
        }
        #endregion
    }
}
