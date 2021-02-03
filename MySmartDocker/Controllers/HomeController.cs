using Common.Redis;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MySmartDocker.Models;
using System;
using System.Diagnostics;
using System.Linq;

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
            //var time = "Latest View Home Index Time Is :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            //var rdsKey = _httpContextAccessor.HttpContext.Request.Headers["X-Real-IP"].ToString();
            var ip = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = this.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
            RedisHelper.StringSet(ip, ip);
            return View();
        }

        public IActionResult SmartRedis()
        {
            ViewBag.Docker = "Docker World--Redis集群";
            var ip = _httpContextAccessor.HttpContext.Request.Headers["X-Forwarded-For"].FirstOrDefault();
            if (string.IsNullOrEmpty(ip))
            {
                ip = this.Request.HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
            }
            ViewBag.Times = RedisHelper.StringGet(ip);
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
