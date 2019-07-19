using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;

namespace HelperLib
{
    public class MyBAL
    {
       public MyBAL(IConfiguration configuration,ILogger<MyBAL> logger)
        {
            var c = configuration["DBConnectionString"];
        }
    }
}
