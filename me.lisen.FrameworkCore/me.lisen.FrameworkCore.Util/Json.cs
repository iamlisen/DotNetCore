using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace me.lisen.FrameworkCore.Util
{
    /// <summary>
    /// 扩展string以及object类，增加ToJson方法进行反序列化以及序列化
    /// </summary>
    public static class Json
    {
        public static object ToJson(this string json)
        {
            return string.IsNullOrEmpty(json) ? null : JsonConvert.DeserializeObject(json);
        }

        public static T ToJson<T>(this string json) where T : class
        {
            return string.IsNullOrEmpty(json) ? null : JsonConvert.DeserializeObject<T>(json);
        }

        public static string ToJson(this object json)
        {
            return json == null ? "" : JsonConvert.SerializeObject(json);
        }
    }
}
