using adminPortal.Context;
using adminPortal.Interfaces.Login;
using adminPortal.Interfaces.Password;
using adminPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Services.Login
{
    public class Login : ILogin
    {
        private readonly ApplicationDbContext _context;
        private readonly IPasswordHasher _PasswordHasher;
        public Login(ApplicationDbContext context, IPasswordHasher passwordHasher)
        {
            _context = context;
            _PasswordHasher = passwordHasher;
        }
        public async Task<List<Authentication>> UserAuthentication(Authentication model)
        {
            try
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    List<Authentication> response = new List<Authentication>();
                    var Email = new SqlParameter("@Admin_Email", model.Admin_Email);
                    response = await _context.Set<Authentication>().FromSqlInterpolated($"EXEC Sp_Get_Encrypted_Admin_Password {Email}").ToListAsync();
                    if (response.Count > 0)
                    {
                        var temp = _PasswordHasher.GenerateIdentityV3Hash(model.Admin_Password);
                        bool flag = _PasswordHasher.VerifyIdentityV3Hash(model.Admin_Password, response[0].Admin_Password);
                        if (flag)
                        {
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task<bool> MatchUserPassword(PasswordRequestModel model)
        {
            try
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    var User_Joined_Email = new SqlParameter("@User_Joined_Email", model.Admin_Email);
                    List<AlreadyAddedPassword> UsersAddedPassword = await _context.Set<AlreadyAddedPassword>().FromSqlInterpolated($"EXEC Sp_Get_Encrypted_Password {User_Joined_Email}").ToListAsync();
                    if (UsersAddedPassword.Count > 0)
                    {
                        bool flag = _PasswordHasher.VerifyIdentityV3Hash(model.Admin_Password, UsersAddedPassword[0].Admin_Password);
                        return flag;
                    }
                    else
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
