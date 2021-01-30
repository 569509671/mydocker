using Common.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MySmartDocker.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MySmartDocker.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public HomeController(/*ILogger<HomeController> logger,*/ IHttpContextAccessor httpContextAccessor)
        {
            //_logger = logger;
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult Index()
        {
            ViewBag.Docker = "Hello World";
            var time = "Latest View Home Index Time Is :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            var rdsKey = "Time:" + _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            RedisHelper.StringSet(rdsKey, time);
            return View();
        }

        public IActionResult SmartRedis()
        {
            ViewBag.Docker = "Docker World--Redis集群";
            var rdsKey = "Time:" + _httpContextAccessor.HttpContext.Connection.RemoteIpAddress.ToString();
            ViewBag.Times = RedisHelper.StringGet(rdsKey);
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
