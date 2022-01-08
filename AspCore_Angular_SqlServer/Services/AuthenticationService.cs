using AspCore_Angular_SqlServer.Models;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace AspCore_Angular_SqlServer.Services
{
    public class AuthenticationService : IAuthenticateService
    {
        private readonly AppSettings _appSettings;
        private readonly ElearningContext _context;
        public AuthenticationService(IOptions<AppSettings> appSettings, ElearningContext context)
        {
            _appSettings = appSettings.Value;
            _context = context;

        }



        private List<Eleve> eleves = new List<Eleve>() {
    new Eleve{Id = 1, Email = "Nehanth@gmail.com", Prenom = "hatem",
            Nom = "attia", password = "123456789" , Niveau="1ére" , Tel=25603243
    }
};
        public Eleve AuthenticateEleve(string Email, string password)
        {
            var eleve = _context.Eleve.FirstOrDefault(x => x.Email == Email && x.password == password);
            //return null if user is not found
            if (eleve == null)
                return null;
            //If user is found
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.key);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, eleve.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Eleve"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
                Expires = DateTime.UtcNow.AddDays(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            eleve.Token = tokenHandler.WriteToken(token);
            eleve.password = null;
            return eleve;

        }
    public Admin AuthenticateAdmin(string Email, string password)
    {
        var admin = _context.Admin.FirstOrDefault(x => x.Email == Email && x.Password == password);
        //return null if user is not found
        if (admin == null)
            return null;
        //If user is found
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.key);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new System.Security.Claims.ClaimsIdentity(new Claim[] {
                    new Claim(ClaimTypes.Name, admin.Id.ToString()),
                    new Claim(ClaimTypes.Role, "Admin"),
                    new Claim(ClaimTypes.Version, "V3.1")
                }),
            Expires = DateTime.UtcNow.AddDays(2),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        admin.Token = tokenHandler.WriteToken(token);
        admin.Password = null;
        return admin;

    }
}
}

