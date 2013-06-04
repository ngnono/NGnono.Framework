using System;
using System.Web;
using System.Web.Mvc;

namespace NGnono.Framework.Web.Mvc.Controllers
{

    public abstract class BackAdminBaseController : BaseController
    {
    }

    /// <summary>
    /// Ҫ������¼�� controller
    /// </summary>
    public abstract class CustomerBaseController : BaseController
    {
        ///// <summary>
        ///// ��ǰ��¼�û�
        ///// </summary>
        //private WebSiteUser _currentUser;

        ///// <summary>
        ///// Gets or sets AuthenticationService.
        ///// </summary>
        //public IAuthenticationService AuthenticationService { get; set; }

        ///// <summary>
        ///// ��ȡ��ǰ��¼�û�
        ///// </summary>
        //public WebSiteUser CurrentUser
        //{
        //    get { return this._currentUser ?? (this._currentUser = this.AuthenticationService.GetCurrentUser(base.HttpContext)); }
        //}

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