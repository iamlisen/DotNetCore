﻿/*
 * 获取配置文件
 * @lisen
 */
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;
using System.IO;
using Microsoft.Extensions.Configuration.Json;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using me.lisen.Bussiness.Entity;

namespace me.lisen.FrameworkCore.Util.config
{
    public static class ConfigManager
    {
        static IConfiguration config = null;
        static ConfigManager()
        {
            string currentClassDir = AppContext.BaseDirectory;
            if (config == null)
            {
                config = new ConfigurationBuilder()
                    .SetBasePath(currentClassDir)
                    .AddJsonFile("appsettings.json", false, true)
                    .Add(new JsonConfigurationSource { Path = "appsettings.json", Optional = false, ReloadOnChange = true })
                    .Build();
            }
        }

        /// <summary>
        /// 获取系统公共配置文件
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="key"></param>
        /// <returns></returns>
        public static T GetValue<T>() where T : class, new()
        {
            T sysConfig = new T();
            try
            {
                config.GetSection("SysConfig").Bind(sysConfig);
            }
            catch (Exception ex)
            {
                sysConfig = null;
            }
            return sysConfig;
        }

        /// <summary>
        /// 获取单一节点配置文件
        /// </summary>
        /// <param name="key">节点，如果是多级节点需要按照:分隔的方式传递</param>
        /// <returns></returns>
        public static string GetValue(string key)
        {
            return config.GetSection(key).Value.ToString().Trim();
        }
    }
}
