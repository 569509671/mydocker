using Common.Redis;
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
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            ViewBag.Docker = "Hello World";
            var time = "Latest View Home Index Time Is :" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            RedisHelper.StringSet("time", time);
            return View();
        }

        public IActionResult SmartRedis()
        {
            ViewBag.Docker = "Docker World--Redis集群";
            ViewBag.Times = RedisHelper.StringGet("time");
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
