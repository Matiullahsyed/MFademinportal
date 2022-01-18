using adminPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace adminPortal.Interfaces.UserLogs
{
    public interface IUserLogs
    {
        Task<List<Users>> DevUserLogs(Pager pager);
        Task<List<Users>> ProdUserLogs(Pager pager);
    }
}
