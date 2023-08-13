﻿using CrudOperationInNetCore.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace CrudOperationInNetCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IConfiguration _config;
        public LoginController(IConfiguration configuration)
        {
            _config = configuration;
            
        }

        private Users AuthenticateUser(Users user )
        {
            Users _user = null;
            if(user.Username == "admin" && user.Password== "Password" ) {
                _user = new Users { Username = "Yogindra" };
            }

            return _user;



        }

        private string GenerateToken(Users users)
        {

            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"], null,
                expires: DateTime.Now.AddDays(1),signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);

        }
        [AllowAnonymous]
        [HttpPost]

        public IActionResult Login(Users user)
        {

            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);

            if(user_ != null) { 

                var token = GenerateToken(user_);
                response = Ok(new {token = token});

            }

            return response;

        }



    }
}
