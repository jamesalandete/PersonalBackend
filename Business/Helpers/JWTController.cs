using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.Extensions.Configuration;
using Data.Entities;

public static class JwtHelper
{
    // INSTANCIAMOS CONFIGURACION
    private static readonly IConfigurationRoot _configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();



    // CONFIGURACION UNICA DE NUESTRA API " ASI SABREMOS CUANDO UNA PETICIÓN ES NUESTRA "
    private static readonly string secretKey = _configuration["Jwt:Key"];
    private static readonly string audienceToken = _configuration["Jwt:Audience"];
    private static readonly string issuerToken = _configuration["Jwt:Issuer"];
    private static readonly string expireTime = _configuration["Jwt:Expire"];

    public static string GenerateJwtToken(AuthUser user)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.Default.GetBytes(secretKey));
        var signingCredentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

        //  CREANDO OBJETO DE IDENTIFICACION
        ClaimsIdentity claimsIdentity = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim("usuario", user.Usuario.ToString()) });

        // CREANDO TOKEN CON NUESTRA INFORMACION DE SEGURIDAD Y EL OBJETO DE NUESTRO USER
        var tokenHandler = new JwtSecurityTokenHandler();
        var jwtSecurityToken = tokenHandler.CreateJwtSecurityToken(
            audience: audienceToken,
            issuer: issuerToken,
            subject: claimsIdentity,
            notBefore: DateTime.UtcNow,
            expires: DateTime.UtcNow.AddMinutes(Convert.ToInt32(expireTime)),
            signingCredentials: signingCredentials);

        // ENCRISTAMOS TODO
        var jwtTokenString = tokenHandler.WriteToken(jwtSecurityToken);
        // DEVOLVEMOS TOKEN
        return jwtTokenString;
    }

    public static bool ValidateJwtToken(string token)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(secretKey);
        try
        {
            tokenHandler.ValidateToken(token, new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = true,
                ValidIssuer = issuerToken,
                ValidateAudience = true,
                ValidAudience = audienceToken,
                ClockSkew = TimeSpan.Zero
            }, out SecurityToken validatedToken);
        }
        catch
        {
            return false;
        }
        return true;
    }
}
