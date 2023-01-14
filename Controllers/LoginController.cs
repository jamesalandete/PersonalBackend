using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using crud.Models;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using System.Configuration;
using ConfigurationManager = System.Configuration.ConfigurationManager;
using Microsoft.Extensions.Configuration;

namespace crud.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly db_personalContext _context;
        private readonly IConfiguration Configuration;

        public LoginController(db_personalContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        [HttpPost]
        [Route("In")]
        public async Task<ActionResult<LoginView>> GetConfigUsuarios( Login login)
        {
            var loginIn = await (from p in _context.ConfigUsuarios where p.Usuario == login.Usuario && p.Pass == login.Pass
                                 select new LoginView
                                 {
                                     Id = p.Id,
                                     Usuario = p.Usuario!,
                                     Token = ""
                                 }).FirstOrDefaultAsync();

            object result = new {};
            if(loginIn == null)
            {
                return BadRequest( new ViewResultado { error = true, mensaje = "Usuario o contraseñas incorrectas", resultado = result });
            }else
            {
               var user =  new UsuarioToken { Id = loginIn.Id, Usuario = loginIn.Usuario };
               string token = generateJwtToken(user);
                loginIn.Token = token;

               return Ok(new ViewResultado { error = false, mensaje = "Se autentico con exito", resultado = loginIn }); ;

            }
        }
        private string generateJwtToken(UsuarioToken user)
        {
            var secretKey = Configuration["Jwt:Key"];
            var audienceToken = Configuration["Jwt:Audience"];
            var issuerToken = Configuration["Jwt:Issuer"];
            var expireTime = Configuration["Jwt:Expire"];

            var securityKey = new SymmetricSecurityKey(System.Text.Encoding.Default.GetBytes(secretKey));
            var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            // create a claimsIdentity
            ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()) , new Claim("usuario", user.Usuario.ToString()) } );

            // create token to the user
            var tokenHandler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
            var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
                audience: audienceToken,
                issuer: issuerToken,
                subject: claimsIdentity,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
                signingCredentials: signingCredentials);

            var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
            return jwtTokenString;
        }


    }
}
