using DocsManagerProject.src.data;
using DocsManagerProject.src.models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;


namespace DocsManagerProject.src.repositories.implements
{
    /// <summary>
    /// <para>Resume: Class for implement interface </para>
    /// <para>By: Higlik </para>
    /// <para>Version: 1.0 </para>
    /// <para>Date: 18/05/2022 </para>
    /// </summary>
    public class TB_USER_Repository : ITB_USER
    {

        #region attributes
        private readonly DocsManagerProjectContext _context;
        #endregion

        #region contructors
        public TB_USER_Repository (DocsManagerProjectContext context)
        {
            _context = context;
        }
        #endregion
        /// <summary>
        /// <para>Resumo: Method for locate email </para>
        /// <para>Criado por: Higlik</para>
        /// <para>Versão: 1.0</para>
        /// <para>Data: 18/05/2022</para>
        /// </summary>
        #region methods
        public async Task<TB_USER> GetUserByEmail(string email)
        {
            return await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);
        }
        #endregion


    }
}

