using DocsManagerProject.src.data;
using DocsManagerProject.src.dto;
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

        #region methods
        /// <summary>
        /// <para>Summary: Asynchronous method to get a user by email</para>
        /// </summary>
        /// <param name="email">Email of user</param>
        /// <return>UserModel</return>
        public async Task<TB_USER> GetUserByEmail(string email)
        {
            return await _context.Users
                    .FirstOrDefaultAsync(u => u.Email == email);
        }

        /// <summary>
        /// <para>Summary: Asynchronous method to add a new user</para>
        /// </summary>
        /// <param name="user">NewUserDTO</param>
        public async Task NewUser(NewUserDTO user)
        {
            await _context.Users.AddAsync(new TB_USER
            {
                Email = user.Email,
                Password = user.Password,
                Type = user.Type
            });
            await _context.SaveChangesAsync();
        }

        #endregion
    }
}

