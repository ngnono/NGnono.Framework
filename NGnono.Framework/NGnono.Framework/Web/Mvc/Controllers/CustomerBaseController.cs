using System;
using System.Web;
using System.Web.Mvc;

namespace NGnono.Framework.Web.Mvc.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class BackAdminBaseController : StandardBaseController
    {
    }

    /// <summary>
    ///  controller
    /// </summary>
    public abstract class StandardBaseController : BaseController
    {
        /// <summary>
        /// 禁用 Response
        /// </summary>
        [Obsolete]
        public new HttpResponseBase Response
        {
            get
            {
                throw new NotSupportedException("禁止直接使用Response");
            }
        }

        /// <summary>
        /// 禁止直接使用Request
        /// </summary>
        [Obsolete]
        public new HttpRequestBase Request
        {
            get
            {
                throw new NotSupportedException("禁止直接使用Request");
            }
        }

        /// <summary>
        /// 禁止直接使用Session
        /// </summary>
        [Obsolete]
        public new HttpSessionStateBase Session
        {
            get
            {
                throw new NotSupportedException("禁止直接使用Session");
            }
        }

        /// <summary>
        /// 禁止直接使用HttpContext
        /// </summary>
        [Obsolete]
        public new HttpContextBase HttpContext
        {
            get
            {
                throw new NotSupportedException("禁止直接使用HttpContext");
            }
        }

        /// <summary>
        /// 禁止直接使用 ControllerContext.
        /// </summary>
        [Obsolete]
        public new ControllerContext ControllerContext
        {
            get
            {
                throw new NotSupportedException("禁止直接使用ControllerContext");
            }
        }
    }
}