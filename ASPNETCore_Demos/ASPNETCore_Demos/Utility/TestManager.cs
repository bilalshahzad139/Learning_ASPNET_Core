using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Demos.Utility
{
    public class TestManager
    {
        public int value = 0;
        private readonly ISession _session;
        private readonly IEmailSender _emailSender;

        public TestManager(IEmailSender emailSender, IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
            _emailSender = emailSender;
        }

        public void TestMethod()
        {
            _emailSender.Send();
        }

        public int GetID()
        {
            if (_session != null)
            {
                return _session.GetInt32("loginid").Value;
            }
            else
                return 0;
        }
    }
}
