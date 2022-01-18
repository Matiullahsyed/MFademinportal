using adminPortal.Interfaces.AddUser;
using adminPortal.Interfaces.Login;
using adminPortal.Interfaces.Password;
using adminPortal.Interfaces.Token;
using adminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace adminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IToken _tokenService;
        private readonly ILogin _login;
        private readonly IPasswordHasher _passwordHasher;
        private readonly IAddUser _UserManagement;
        public AccountController(IToken tokenService, ILogin login, IPasswordHasher passwordHasher, IAddUser UserManagement)
        {
            _tokenService = tokenService;
            _login = login;
            _passwordHasher = passwordHasher;
            _UserManagement = UserManagement;
        }
        [HttpPost("add_New_User")]
        public async Task<bool> AddNewUsers(AddNewUser model)
        {
            try
            {
                if(ModelState.IsValid)
                {
                    if(String.IsNullOrEmpty(model.Admin_Email))
                    {
                        return false;
                    }
                    if(String.IsNullOrEmpty(model.Admin_Password))
                    {
                        return false;
                    }
                        model.Admin_Password = _passwordHasher.GenerateIdentityV3Hash(model.Admin_Password);
                        var response = await _UserManagement.AddUserForAdmin(model);
                        if (response != false)
                        {
                            return response;
                        }
                        else
                        {
                            return false;
                        }
                    
                    
                }
                else
                {
                    return false;
                }
            }
            catch (System.Exception ex)
            {
                return false;
            }
        }

        [HttpPost("login")]
        public async Task<List<Authentication>> User_Authentication(Authentication model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    List<Authentication> response = new List<Authentication>();
                     response = await _login.UserAuthentication(model);
                    if (response != null)
                    {
                        var claims = new[] {
                            new Claim(JwtRegisteredClaimNames.Sid, Guid.NewGuid().ToString())
                        };
                        var token = _tokenService.GenerateAccessToken(claims);
                        response[0].User_Token = token;
                        return response;
                    }
                    else
                    {
                        return null;
                    }
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
       
    }
}
