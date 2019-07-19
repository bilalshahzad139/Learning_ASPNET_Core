using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASPNETCore_Demos.Models;
using BALHelper;
using Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;


namespace ASPNETCore_Demos.Controllers
{
    public class UserController : Controller
    {
        public UserController(IOptions<MyCustomSettings> appSettings)
        {
            var id = appSettings.Value.AppID;
            var appName = appSettings.Value.AppName;
            var isallowed = appSettings.Value.IsAllowed;
        }
        [HttpGet]
        public IActionResult Login()
        {
            var a = this.HttpContext.RequestServices.GetService<MyCustomBAL>();
            //var v = a.GetConfigValue();
            var v = a.GetConfigValue2();

            return View(new LoginDTO());
        }

        [HttpPost]
        [ActionName("Login")]
        public IActionResult Login4(LoginDTO dto)
        {

            if (UserManager.ValidateUser(dto.Login,dto.Password) == true)
            {
                ViewBag.Msg = "Valid User!";
            }
            else
            {
                ViewBag.Msg = "Invalid User!";
            }
            return View("Login",dto);
        }
    }
}