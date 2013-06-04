using System;
using System.Web;
using System.Web.Mvc;
using NGnono.Framework.Models;
using NGnono.Framework.Web.Mvc.ActionResults;
using NGnono.Framework.Web.Mvc.Attributes;

namespace NGnono.Framework.Web.Mvc.Controllers
{
    [DataService]
    public abstract class RestfulController : BaseController
    {
        protected ActionResult RestfulResult(ExecuteResult data)
        {
            return new RestfulResult
            {
                Data = data
            };
        }

        /// <summary>
        /// url 解码
        /// </summary>
        /// <param name="encodeString"></param>
        /// <returns></returns>
        public static string UrlDecode(string encodeString)
        {
            return String.IsNullOrWhiteSpace(encodeString) ? String.Empty : HttpUtility.UrlDecode(encodeString);
        }
    }
}
