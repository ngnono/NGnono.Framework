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
        /// ���� Response
        /// </summary>
        [Obsolete]
        public new HttpResponseBase Response
        {
            get
            {
                throw new NotSupportedException("��ֱֹ��ʹ��Response");
            }
        }

        /// <summary>
        /// ��ֱֹ��ʹ��Request
        /// </summary>
        [Obsolete]
        public new HttpRequestBase Request
        {
            get
            {
                throw new NotSupportedException("��ֱֹ��ʹ��Request");
            }
        }

        /// <summary>
        /// ��ֱֹ��ʹ��Session
        /// </summary>
        [Obsolete]
        public new HttpSessionStateBase Session
        {
            get
            {
                throw new NotSupportedException("��ֱֹ��ʹ��Session");
            }
        }

        /// <summary>
        /// ��ֱֹ��ʹ��HttpContext
        /// </summary>
        [Obsolete]
        public new HttpContextBase HttpContext
        {
            get
            {
                throw new NotSupportedException("��ֱֹ��ʹ��HttpContext");
            }
        }

        /// <summary>
        /// ��ֱֹ��ʹ�� ControllerContext.
        /// </summary>
        [Obsolete]
        public new ControllerContext ControllerContext
        {
            get
            {
                throw new NotSupportedException("��ֱֹ��ʹ��ControllerContext");
            }
        }
    }
}