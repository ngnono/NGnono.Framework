using NGnono.Framework.Models;
using NGnono.Framework.Web.Mvc.ActionResults;
using NGnono.Framework.Web.Mvc.Attributes;
using System.Web.Mvc;

namespace NGnono.Framework.Web.Mvc.Controllers
{
    /// <summary>
    /// 
    /// </summary>
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
    }
}
