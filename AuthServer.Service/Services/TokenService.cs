using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using AuthServer.Core.Configuration;
using AuthServer.Core.Dtos;
using AuthServer.Core.Models;
using AuthServer.Core.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using SharedLibrary.Configurations;

namespace AuthServer.Service.Services
{
    public class TokenService:ITokenService
    {
        private readonly UserManager<UserApp> _userManager;
        private readonly CustomTokenOptions _tokenOptions;

        public TokenService(UserManager<UserApp> userManager, IOptions<CustomTokenOptions> tokenOptions)
        {
            _userManager = userManager;
            _tokenOptions = tokenOptions.Value;
        }

        private string CreateRefreshToken()
        {
            var numberByte = new Byte[32];

            using var rnd = RandomNumberGenerator.Create();

            rnd.GetBytes(numberByte);

            return Convert.ToBase64String(numberByte);
        }

        public TokenDto CreateToken(UserApp userApp)
        {
            throw new NotImplementedException();
        }

        public ClientTokenDto CreateTokenByClient(Client client)
        {
            throw new NotImplementedException();
        }
    }
}
