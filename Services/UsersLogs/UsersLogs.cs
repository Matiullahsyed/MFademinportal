using adminPortal.Context;
using adminPortal.Interfaces.UserLogs;
using adminPortal.Models;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace adminPortal.Services.UsersLogs
{
    public class UsersLogs : IUserLogs
    {
        private readonly ApplicationDbContext _context;
        private readonly ProductionDbContext _contextP;
        public UsersLogs(ApplicationDbContext context, ProductionDbContext contextP)
        {
            _context = context;
            _contextP = contextP;
        }
        public async Task<List<Users>> DevUserLogs(Pager pager)
        {
            try
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    List<Users> pagination = new List<Users>();
                    var PageNumber = new SqlParameter("@PageNumber", pager.CurrentPageIndex);
                    var RowsOfPage = new SqlParameter("@RowsOfPage", pager.PerPageCount);
                    pagination = await _context.Set<Users>().FromSqlInterpolated($"EXEC Sp_WatchUserLogs_v1 {PageNumber},{RowsOfPage}").ToListAsync();
                    if (pagination.Count > 0)
                    {
                        pagination[0].TotalRecords = pagination[0].TotalRecords / pager.PerPageCount;
                        return pagination;
                    }
                    else
                    {
                        return pagination;
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<Users>> ProdUserLogs(Pager pager)
        {
            try
            {
                using (SqlCommand comm = new SqlCommand())
                {
                    List<Users> pagination = new List<Users>();
                    var PageNumber = new SqlParameter("@PageNumber", pager.CurrentPageIndex);
                    var RowsOfPage = new SqlParameter("@RowsOfPage", pager.PerPageCount);
                    pagination = await _contextP.Set<Users>().FromSqlInterpolated($"EXEC Sp_WatchUserLogs_v1 {PageNumber},{RowsOfPage}").ToListAsync();
                    if (pagination.Count > 0)
                    {
                        pagination[0].TotalRecords = pagination[0].TotalRecords / pager.PerPageCount;
                        return pagination;
                    }
                    else
                    {
                        return pagination;
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
