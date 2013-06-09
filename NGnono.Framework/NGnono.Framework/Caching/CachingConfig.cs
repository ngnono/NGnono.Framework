using System;
using System.Configuration;

namespace NGnono.Framework.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public class CachingConfig
    {
        private const string CachingProvider = "CacheProvider";

        /// <summary>
        /// 
        /// </summary>
        public static bool IsCloseService
        {
            get { return Boolean.Parse(GetAppkey(Define.IsCloseService)); }
        }

        /// <summary>
        /// 
        /// </summary>
        public static bool IsEnableSign
        {
            get { return Boolean.Parse(GetAppkey(Define.IsEnableSign)); }
        }

        /// <summary>
        /// 获取应用程序key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetAppkey(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }

        /// <summary>
        /// 获取cacheprovider
        /// </summary>
        /// <returns></returns>
        public static string GetCacheProvider()
        {
            return GetAppkey(CachingProvider);
        }
    }
}
