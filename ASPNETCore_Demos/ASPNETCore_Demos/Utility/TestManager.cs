using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Demos.Utility
{
    public class TestManager
    {
        public int value = 0;

        private readonly IEmailSender _emailSender;
        public TestManager(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        public void TestMethod()
        {
            _emailSender.Send();
        }
    }
}
