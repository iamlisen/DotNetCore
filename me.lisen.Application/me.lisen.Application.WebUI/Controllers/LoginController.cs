using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using System.IO;
using Microsoft.AspNetCore.Http;

namespace me.lisen.Application.WebUI.Controllers
{
    public class LoginController : Controller
    {

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        /// <summary>
        /// 返回 验证码
        /// </summary>
        /// <returns></returns>
        public ActionResult VerifyCode()
        {
            string vCode = string.Empty;
            MemoryStream memoryStream = me.lisen.Application.Code.VerifyCode.CreateImage(out vCode);
            HttpContext.Session.SetString("VCode",vCode);
            return File(memoryStream.ToArray(),@"image/png");
        }

        
    }
}