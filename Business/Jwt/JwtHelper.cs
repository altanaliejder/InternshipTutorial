using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Business.Jwt
{
    public class JwtHelper : ITokenHelper
    {
        private IConfiguration _configration;
        private DateTime _accessTokenExpiration;
        private TokenOptions _tokenOptions;

        public JwtHelper(IConfiguration configuration)
        {
            _configration = configuration;
            _tokenOptions = _configration.GetSection("TokenOptions").Get<TokenOptions>();
        }



        public AccessToken CreateToken(User user, List<OperationClaim> operationClaims)
        {
            _accessTokenExpiration = DateTime.Now.AddMinutes(_tokenOptions.AccessTokenExpiration);
            var securityKey = SecurityKeyHelper.CreateSecurityKey(_tokenOptions.SecurityKey);
            var signingCredentials = SigningCredentialsHelper.CreateSigningCredentials(securityKey);
            var jwt = CreateJwtSecurityToken(_tokenOptions, user, signingCredentials,operationClaims);
            var jwtSecurityHandler = new JwtSecurityTokenHandler();
            var token = jwtSecurityHandler.WriteToken(jwt);

            return new AccessToken
            {
                Token = token,
                Expiration = _accessTokenExpiration
            };
        }


        public JwtSecurityToken CreateJwtSecurityToken(TokenOptions tokenOptions,User user, SigningCredentials signingCredentials, List<OperationClaim> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience:tokenOptions.Audience,
                signingCredentials:signingCredentials,
                claims:SetClaims(user,operationClaims),
                expires:_accessTokenExpiration,
                notBefore:DateTime.Now
                );
            return jwt;
            
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaim> operationClaims)
        {
            var claims = new List<Claim>();
            claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));
            claims.Add(new Claim(ClaimTypes.Name, user.Name));
            claims.Add(new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()));
            claims.Add(new Claim(ClaimTypes.Name, user.Name+user.Surname));
            claims.Add(new Claim(ClaimTypes.UserData, user.Name));
            operationClaims.ForEach(role => claims.Add(new Claim(ClaimTypes.Role, role.Name)));

            return claims;
        }
    }
}
