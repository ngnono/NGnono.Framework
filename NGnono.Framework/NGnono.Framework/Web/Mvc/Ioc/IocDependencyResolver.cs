using System;
using System.Collections.Generic;
using System.Web.Mvc;
using System.Web.Routing;
using NGnono.Framework.ServiceLocation;

namespace NGnono.Framework.Web.Mvc.Ioc
{
    /// <summary>
    /// MVC 3中使用
    /// </summary>
    public class CustomControllerActivator : IControllerActivator
    {
        #region Implementation of IControllerActivator

        /// <summary>
        /// When implemented in a class, creates a controller.
        /// </summary>
        /// <returns>
        /// The created controller.
        /// </returns>
        /// <param name="requestContext">The request context.</param><param name="controllerType">The controller type.</param>
        IController IControllerActivator.Create(RequestContext requestContext, Type controllerType)
        {
            return DependencyResolver.Current.GetService(controllerType) as IController;
        }

        #endregion
    }

    public class IocDependencyResolver : IDependencyResolver
    {
        public object GetService(Type serviceType)
        {
            try
            {
                return ServiceLocator.Current.Resolve(serviceType);
            }
            catch (Microsoft.Practices.Unity.ResolutionFailedException ex)
            {
                Exception e = ex;
                while (e != null)
                {
                    Logger.LoggerManager.Current().Error(e);

                    e = e.InnerException;
                }
            }
            catch (Exception ex)
            {
                // 在没有解析到任何对象的情况下，必须返回 null
            }

            return null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            try
            {
                return ServiceLocator.Current.ResolveAll(serviceType);
            }
            catch
            {
                // 在没有解析到任何对象的情况下，必须返回空集合
                return new List<object>();
            }
        }
    }
}
