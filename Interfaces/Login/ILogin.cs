using adminPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Interfaces.Login
{
    public interface ILogin
    {
        Task<List<Authentication>> UserAuthentication(Authentication model);
        Task<bool> MatchUserPassword(PasswordRequestModel model);
    }
}
