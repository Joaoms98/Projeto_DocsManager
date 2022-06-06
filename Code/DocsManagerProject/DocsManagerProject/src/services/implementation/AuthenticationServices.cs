using DocsManagerProject.src.dto;
using DocsManagerProject.src.models;
using DocsManagerProject.src.repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace DocsManagerProject.src.services.implementation
{
    public class AuthenticationServices : IAuthentication
    {
        #region Attributes
        private readonly ITB_USER _repository;
        public IConfiguration Configuration { get; }
        #endregion

        #region Constructors
        public AuthenticationServices(ITB_USER repository, IConfiguration configuration)
        {
            _repository = repository;
            Configuration = configuration;
        }
        #endregion

        #region Method
        /// <summary>
        /// <para>Resumo: Asynchronous method responsible for enconding password</para>
        /// </summary>
        /// <param name="password">AuthenticationServices</param>
        public string EncodePassword(string password)
        {
            var bytes = Encoding.UTF8.GetBytes(password);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// <para>Resumo: Asynchronous method responsible for creating user without duplicating in the database</para>
        /// </summary>
        /// <param name="dto">NewUserDTO</param>
        public async Task CreateUserNotDuplicated(NewUserDTO dto)
        {
            var user = await _repository.GetUserByEmail(dto.Email);
            if (user != null) throw new Exception("This email is already being used");
            dto.Password = EncodePassword(dto.Password);
            await _repository.NewUser(dto);
        }

        /// <summary>
        /// <para>Resumo: Method responsible for generating JWT token</para>
        /// </summary>
        /// <param name="user">UsuarioModelo</param>
        /// <returns>string</returns>
        public string GenerateToken(TB_USER user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration["Settings:Secret"]);
            var tokenDescription = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(
            new Claim[]
            {
                new Claim(ClaimTypes.Email, user.Email.ToString()),
                new Claim(ClaimTypes.Role, user.Type.ToString())
            }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(
            new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature
            )
            };
            var token = tokenHandler.CreateToken(tokenDescription);
            return tokenHandler.WriteToken(token);
        }

        /// <summary>
        /// <para>Resumo: Responsible async method return authorization to authenticated user</para>
        /// </summary>
        /// <param name="authentication">AutenticarDTO</param>
        /// <returns>AuthenticateDTO</returns>
        /// <exception cref="Exception">User not found</exception>
        /// <exception cref="Exception">Incorrect password</exception>
        public async Task<AuthorizationDTO> GetAuthorization(AuthenticateDTO authentication)
        {
            var user = await _repository.GetUserByEmail(authentication.Email);
            if (user == null) throw new Exception("User not found");
            if (user.Password != EncodePassword(authentication.Password)) throw new Exception("Incorrect Password");
            return new AuthorizationDTO(user.Email, user.Type, GenerateToken(user));
        }
        #endregion
    }
}
