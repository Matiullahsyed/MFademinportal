using adminPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Interfaces.AddUser
{
    public interface IAddUser
    {
        Task<bool> AddUserForAdmin(AddNewUser model);
    }
}
