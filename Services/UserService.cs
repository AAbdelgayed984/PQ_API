using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using PQ_API.Classes;
using PQ_API.DataConnect;
using PQ_API.Helpers;
using PQ_API.Interfaces;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace PQ_API.Services
{
    public class UserService : IUserService
    {
        private readonly AppSettings _appSettings;
        private List<User> _users;
        public UserService(IOptions<AppSettings> appSettings, RubiDBSettings rubiDBSettings)
        {
            _appSettings = appSettings.Value;
            RUBIDataConnect rubiDataConnect = new RUBIDataConnect(rubiDBSettings.ConnectionString);
            _users = rubiDataConnect.GetAPIUsersListFunc();
        }
        
        public AuthenticateResponse Authenticate(AuthenticateRequest model)
        {
            var user = _users.SingleOrDefault(x => x.Username == model.Username && x.Password == model.Password);

            // return null if user not found
            if (user == null) return null;

            // authentication successful so generate jwt token
            var token = generateJwtToken(user);

            return new AuthenticateResponse(user, token);
        }

        public IEnumerable<User> GetAll()
        {
            return _users;
        }

        public User GetById(string userId)
        {
            return _users.FirstOrDefault(x => x.UserId == userId);
        }

        // helper methods

        private string generateJwtToken(User user)
        {
            // generate token that is valid for 7 days
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.UserId.ToString()) }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}