using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MultiShop.IdentityServer.Tools
{
    public class JwtTokenGenerator
    {
        public static TokenResponseViewModel GenerateToken(GetCheckAppUserViewModel model)
        {
            var claims = new List<Claim>();
            if (!string.IsNullOrWhiteSpace(model.Role))
            {
                claims.Add(new Claim(ClaimTypes.Role, model.Role));
                //Kullanıcının Rolü var ise bu rolü Claim olarak JWT'ye ekleriz.
            }

            //Her kullanıcın benzersiz olan ID değeri NameIdentifier olarak claim'e eklenir.
            claims.Add(new Claim(ClaimTypes.NameIdentifier,model.Id));

            if(!string.IsNullOrWhiteSpace(model.Username))
            {
                claims.Add(new Claim("Username", model.Username));
                //Kullanıcın username değeri var ise bu değer claim'e eklenir
            }

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(JwtTokenDefaults.Key));
            var sigingCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var expireDate = DateTime.UtcNow.AddDays(JwtTokenDefaults.Expire);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: JwtTokenDefaults.ValidIssuer, // Token'ı oluşturan kişi
                audience: JwtTokenDefaults.ValidIssuer, // Hangi uygulamanın token'ı kullanacığını bildirir.
                claims: claims, // Token içinde yer alan bilgileri içerir.
                notBefore: DateTime.UtcNow, // Token'ın geçerli olmaya başlayacağı zaman.
                expires: expireDate, // Token'ın sona ereceği zaman.
                sigingCredentials); // Token için gerekli güvenlik bilgilerini içerir.

            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            return new TokenResponseViewModel(tokenHandler.WriteToken(token),expireDate);
        }
    }
}
