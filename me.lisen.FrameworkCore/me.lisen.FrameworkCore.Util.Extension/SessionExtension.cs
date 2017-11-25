using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.lisen.FrameworkCore.Util.Extension
{
    /// <summary>
    /// 扩展Session方法
    /// </summary>
    public static class SessionExtension
    {
        /// <summary>
        /// 序列化
        /// </summary>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <param name="value"></param>
        public static void SetObject(this ISession session,string key,object value)
        {
            session.SetString(key,JsonConvert.SerializeObject(value));
        }

        /// <summary>
        /// 获取对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="session"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetObject<T>(this ISession session,string key)
        {
            return JsonConvert.DeserializeObject<T>(session.GetString(key));
        }
    }
}
