using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ASPNETCore_Demos.Models;
using ASPNETCore_Demos.Utility;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;

namespace ASPNETCore_Demos.Controllers
{
    public class HomeController : Controller
    {
        private readonly IServiceProvider _serviceProvider;

        public HomeController(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public IActionResult Index([FromServices] IEmailSender emailSender)
        {
            //emailSender.Send();

            //var t2 = (TestManager)_serviceProvider.GetService(typeof(TestManager));
            //var t3 = _serviceProvider.GetService<TestManager>();
            //var t4 = _serviceProvider.GetRequiredService<TestManager>();

            var id = this.HttpContext.Session.GetInt32("loginid");
            if(id != null && id > 0)
            {
                var t2 = (TestManager)_serviceProvider.GetService(typeof(TestManager));
                var i = t2.GetID();
                return View();
            }
            else
            {
                return Redirect("~/User/Login");
            }
            
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
