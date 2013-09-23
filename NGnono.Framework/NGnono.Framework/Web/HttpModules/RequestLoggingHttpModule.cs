using NGnono.Framework.Logger;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Text;
using System.Web;

namespace NGnono.Framework.Web.HttpModules
{
    /// <summary>
    /// CLR Version: 4.0.30319.269
    /// NameSpace: Yintai.Architecture.Framework.Web.HttpModules
    /// FileName: Class1
    ///
    /// Created at 11/8/2012 7:50:21 PM
    /// Description: 
    /// </summary>
    /// <summary>
    /// 请求记录日志
    /// </summary>
    public class RequestLoggingHttpModule : IHttpModule
    {
        #region fileds

        private static readonly ILog Log = LoggerManager.Current();

        #endregion

        #region IHttpModule Members

        public void Dispose()
        {

        }

        public void Init(HttpApplication context)
        {
            context.BeginRequest += context_BeginRequest;
        }

        static void context_BeginRequest(object sender, EventArgs e)
        {
            var context = sender as HttpApplication;

            if (context == null)
            {
                Log.Error("RequestLoggingHttpModule Parameter context is null");
                return;
            }
            //string form = context.Context.Request.Form.ToJson();
            //string query = context.Context.Request.QueryString.ToJson();

            //logging the Request
            var sb = new StringBuilder();

            sb.AppendFormat("{0} [ {1} ] ", context.Context.Request.Url, DateTime.Now);
            sb.AppendLine();

            sb.AppendLine();
            sb.AppendLine("[ Headers ]");
            sb.AppendLine();

            foreach (string key in context.Context.Request.Headers)
            {
                sb.AppendFormat("{0} : {1}", key, context.Context.Request.Headers[key]);
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.AppendLine("[ QueryString ]");
            sb.AppendLine();

            foreach (string key in context.Context.Request.QueryString)
            {
                sb.AppendFormat("{0} : {1}", key, context.Context.Request.QueryString[key]);
                sb.AppendLine();
            }

            sb.AppendLine();
            sb.AppendLine("[ Form ]");
            sb.AppendLine();

            foreach (string key in context.Context.Request.Form)
            {
                sb.AppendFormat("{0} : {1}", key, context.Context.Request.Form[key]);
                sb.AppendLine();
            }

            Log.Info(sb.ToString());
        }

        #region helper

        /// <summary>
        /// 
        /// </summary>
        /// <param name="collection"></param>
        /// <returns></returns>
        public Dictionary<string, string> NameValueCollectionToDictionary(NameValueCollection collection)
        {
            var dict = new Dictionary<string, string>();
            foreach (string key in collection.Keys)
            {
                dict.Add(key, collection[key]);
            }

            return dict;
        }

        #endregion

        #endregion
    }
}
