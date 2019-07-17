using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASPNETCore_Demos.Utility
{
    public class SessionManager
    {
        private readonly ISession _session;
        private const String ID_KEY = "_ID";
        private const String LOGIN_KEY = "_LoginName";
        public SessionManager(IHttpContextAccessor httpContextAccessor)
        {
            _session = httpContextAccessor.HttpContext.Session;
        }

        public int ID
        {
            get
            {
                var v = _session.GetInt32(ID_KEY);
                if (v.HasValue)
                    return v.Value;
                else
                    return 0;
            }
            set
            {
                _session.SetInt32(ID_KEY, value);
            }
        }
        public String LoginName
        {
            get
            {
                return _session.GetString(LOGIN_KEY);
            }
            set
            {
                _session.SetString(LOGIN_KEY, value);
            }
        }
        public Boolean IsLoggedIn
        {
            get
            {
                if (ID > 0)
                    return true;
                else
                    return false;
            }
        }
    }
}
