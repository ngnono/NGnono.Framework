using NGnono.Framework.Logger;
using NGnono.Framework.ServiceLocation;
using NGnono.Framework.Web.Mvc.Attributes;
using System;
using System.Web;

namespace NGnono.Framework.Web.Mvc.Controllers
{
    /// <summary>
    /// ���е�controller������̳�BaseController
    /// </summary>
    [DefaultHandleError]
    public abstract class BaseController : System.Web.Mvc.Controller
    {
        protected BaseController()
        {
            Logger = LoggerManager.Current();
        }

        #region properties

        protected ILog Logger { get; set; }

        #endregion

        #region methods

        /// <summary>
        /// �ṩ��ȡService�ķ���
        /// </summary>
        /// <typeparam name="TService">Service����</typeparam>
        /// <returns>��ȡ����ʵ��</returns>
        protected static TService GetService<TService>()
        {
            return ServiceLocator.Current.Resolve<TService>();
        }

        /// <summary>
        /// �ṩ��ȡService�ķ��������ݼ�ֵ
        /// </summary>
        /// <typeparam name="TService">Service����</typeparam>
        /// <param name="key">ָ���ļ�ֵ</param>
        /// <returns>��ȡ����ʵ��</returns>
        protected static TService GetService<TService>(string key)
        {
            return ServiceLocator.Current.Resolve<TService>(key);
        }

        #endregion

        /// <summary>
        /// url ����
        /// </summary>
        /// <param name="encodeString"></param>
        /// <returns></returns>
        public static string UrlDecode(string encodeString)
        {
            return String.IsNullOrWhiteSpace(encodeString) ? String.Empty : HttpUtility.UrlDecode(encodeString);
        }
    }
}