using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Demos.Utility
{
    public interface IEmailSender
    {
        void Send();
        String GetSMTP();
    }
    public class EmailSender : IEmailSender
    {
        private readonly ILogger _logger;
        //Lets use Logger in this class through DI
        public EmailSender(ILogger<EmailSender> logger)
        {
            _logger = logger;
        }
        public void Send()
        {
            _logger.LogInformation("Send is called!");
            //Does something here
        }

        public String GetSMTP()
        {
            return "test.smtp.com";
        }
    }
}
