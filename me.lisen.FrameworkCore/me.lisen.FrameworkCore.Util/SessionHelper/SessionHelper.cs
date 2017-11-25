using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Session;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using me.lisen.FrameworkCore.Util.Extension;

namespace me.lisen.FrameworkCore.Util.SessionHelper
{
    public class SessionHelper
    {
        private IHttpContextAccessor httpContextAccessor;
        private ISession _session => httpContextAccessor.HttpContext.Session;

        public SessionHelper(IHttpContextAccessor accessor)
        {
            httpContextAccessor = accessor;
        }

        public void SetSession(string key, string value)
        {
            _session.SetString(key, value);
        }

        public string GetSession(string key)
        {
            return _session.GetString(key);
        }

        public void SetSession(string key, object value)
        {
            _session.SetObject(key, value);
        }

        public T GetSession<T>(string key)
        {
            return _session.GetObject<T>(key);

        }
    }
}
