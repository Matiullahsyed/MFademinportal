using adminPortal.Context;
using adminPortal.Interfaces.AddUser;
using adminPortal.Models;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Services.AddUser
{
    public class AddUser : IAddUser
    {
        private readonly ApplicationDbContext _context;
        public AddUser(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<bool> AddUserForAdmin(AddNewUser model)
        {
            try
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    var Email = new SqlParameter("@e", model.Admin_Email);
                    var HashPassword = new SqlParameter("@p", model.Admin_Password);
                    int response = await _context.Database.ExecuteSqlRawAsync($"EXEC sp_AddNewUser @e,@p", Email, HashPassword);
                    if (response > 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return false;
        }
    }
}
