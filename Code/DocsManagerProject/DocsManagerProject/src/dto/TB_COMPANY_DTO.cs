using System.ComponentModel.DataAnnotations;

namespace DocsManagerProject.src.dto
{
    /// <Sumary>
    /// <para>Resume> Creating DTO for insert new company </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:17/05/2022</para>
    /// </summary>
    public class NewCompanyDTO
    {
        [Required]
        public string Trade_Name { get; set; }

        [Required]
        public string CNPJ { get; set; }

        public string Telephone { get; set; }

        public string Agent { get; set; }

        public NewCompanyDTO(string trade_name, string cnpj, string telephone, string agent)
        {
            Trade_Name = trade_name;
            CNPJ = cnpj;
            Telephone = telephone;
            Agent = agent;
        }
    }
    /// <Sumary>
    /// <para>Resume> Creating DTO for update company </para>
    /// <para>By: Joaoms98 <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:17/05/2022</para>
    /// </summary>
    public class UpdateCompanyDTO
    {
        [Required]
        public int Id_Company { get; set; }

        [Required]
        public string Trade_Name { get; set; }

        public string Telephone { get; set; }
        
        public string Agent { get; set; }

        public UpdateCompanyDTO(string trade_name, string telephone, string agent)
        {
            Trade_Name = trade_name;
            Telephone = telephone;
            Agent = agent;
        }
    }
}

