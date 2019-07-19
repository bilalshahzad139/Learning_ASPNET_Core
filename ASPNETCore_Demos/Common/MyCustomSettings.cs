using System;
using System.Collections.Generic;

namespace Common
{
    public class MyCustomSettings
    {
        public int AppID { get; set; }
        public String AppName { get; set; }
        public Boolean IsAllowed { get; set; }

        public List<String> Urls { get; set; }
    }
}
