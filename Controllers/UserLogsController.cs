using adminPortal.Interfaces.UserLogs;
using adminPortal.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace adminPortal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserLogsController : ControllerBase
    {

        private readonly IUserLogs _userLogs;
        private IConfiguration _configuration;
        public UserLogsController(IUserLogs userLogs, IConfiguration configuration)
        {
            _configuration = configuration;
            _userLogs = userLogs;
        }
        [HttpPost]
        [Route("dev_logs")]
        public async Task<List<Users>> Dev(Pager pager)
        {
            try
            {
                if (pager.CurrentPageIndex == 0 )
                {
                    pager.CurrentPageIndex = 1;
                }
                if (pager.PerPageCount == 0)
                {

                    pager.PerPageCount = 20;
                }
                var response = await _userLogs.DevUserLogs(pager);
                if(response != null)
                {
                     return response;
                }
                return null;
                
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        [HttpPost]
        [Route("Pro_logs")]
        public async Task<List<Users>> Pro(Pager pager)
        {
            try
            {
                if (pager.CurrentPageIndex == 0)
                {
                    pager.CurrentPageIndex = 1;
                }
                if (pager.PerPageCount == 0)
                {

                    pager.PerPageCount = 20;
                }
                var response = await _userLogs.ProdUserLogs(pager);
                if (response != null)
                {
                    return response;
                }
                return null;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }
        [HttpGet]
        [Route("Feed_Reschedular")]
        public async Task<bool> FeedSchedular()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                   string uri= _configuration.GetSection("SchedulerApi").GetValue<string>("ProdControllerUrl");
                    using (var response = await httpClient.PostAsync(uri, null))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var boolResponse = JsonConvert.DeserializeObject(apiResponse);
                        if((bool)(boolResponse = true))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }
            
        }
        [HttpGet]
        [Route("Dev_Feed_Reschedular")]
        public async Task<bool> DevFeedSchedular()
        {
            try
            {
                using (var httpClient = new HttpClient())
                {
                    string uri = _configuration.GetSection("SchedulerApi").GetValue<string>("DevControllerUrl");
                    using (var response = await httpClient.PostAsync(uri, null))
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        var boolResponse = JsonConvert.DeserializeObject(apiResponse);
                        if ((bool)(boolResponse = true))
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }
                    }
                }
                return false;
            }
            catch (System.Exception ex)
            {
                throw ex;
            }

        }

    }
}

