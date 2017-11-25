using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using me.lisen.FrameworkCore.Util.Extension;
using me.lisen.FrameworkCore.Util.SessionHelper;
using Microsoft.Extensions.Caching.Distributed;

namespace me.lisen.Application.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private IDistributedCache cache;
        public HomeController(IDistributedCache cache)
        {
            this.cache = cache;
        }

        [HttpGet]
        public IActionResult Index()
        {
            cache.SetString("name","lisen");
            ViewBag.name = cache.GetString("name");
            return View();
        }

        public IActionResult Index2()
        {
            ViewBag.name = cache.GetString("name");
            return View();
        }
    }
}