using DocsManagerProject.src.models;
using Microsoft.EntityFrameworkCore;

namespace DocsManagerProject.src.data
{
    /// <Sumary>
    /// <para>Resume> Creating context for TB</para>
    /// <para>By: Joaoms98 and Higlik <para>
    /// <para>Version: 1.0</para>
    /// <para>Date:16/05/2022</para>
    /// </summary>
    public class DocsManagerProjectContext : DbContext
    {
        public DbSet<TB_BANK_SLIP> BankSlips {get; set;}
        public DbSet<TB_COMPANY> Companies { get; set; }
        public DbSet<TB_USER> Users { get; set; }
        
        public DocsManagerProjectContext(DbContextOptions<DocsManagerProjectContext> opt) : base(opt)
        {
        }
    }
}
