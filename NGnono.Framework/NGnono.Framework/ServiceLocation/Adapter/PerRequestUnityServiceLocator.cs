using System;
using System.Collections.Generic;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Linq;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using Microsoft.Web.Infrastructure.DynamicModuleHelper;
using NGnono.Framework.Data.EF;

namespace NGnono.Framework.ServiceLocation.Adapter
{
    public class PerRequestUnityServiceLocator : ServiceLocatorBase
    {
        private const string HttpContextKey = "perRequestContainer";

        private readonly IUnityContainer _container;

        public PerRequestUnityServiceLocator()
        {
            _container = new UnityContainer();

            if (ConfigurationManager.GetSection(UnityConfigurationSection.SectionName) != null)
            {
                try
                {
                    var configuration = (UnityConfigurationSection)ConfigurationManager.GetSection(UnityConfigurationSection.SectionName);
                    configuration.Configure(_container, "defaultContainer");
                }
                catch (Exception ex)
                {
                    while (ex != null)
                    {
                        Logger.Error(ex);
                        ex = ex.InnerException;
                    }

                    throw;
                }
            }
        }

        public object GetService(Type serviceType)
        {
            if (typeof(IController).IsAssignableFrom(serviceType))
            {
                return ChildContainer.Resolve(serviceType);
            }

            if (typeof(IUnitOfWork).IsAssignableFrom(serviceType))
            {
                return ChildContainer.Resolve(serviceType);
            }

            return IsRegistered(serviceType) ? ChildContainer.Resolve(serviceType) : null;
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (IsRegistered(serviceType))
            {
                yield return ChildContainer.Resolve(serviceType);
            }

            foreach (var service in ChildContainer.ResolveAll(serviceType))
            {
                yield return service;
            }
        }

        protected IUnityContainer ChildContainer
        {
            get
            {
                IUnityContainer childContainer = null;
                if (HttpContext.Current != null)
                {
                    var cachedContainer = HttpContext.Current.Items[HttpContextKey];

                    if (cachedContainer is IUnityContainer)
                    {
                        childContainer = cachedContainer as IUnityContainer;
                    }
                    else
                    {
                        HttpContext.Current.Items[HttpContextKey] = childContainer = _container.CreateChildContainer();
                    }
                }

                if (childContainer == null)
                    childContainer = _container;


                return childContainer;
            }
        }

        public static void DisposeOfChildContainer()
        {
            var childContainer = HttpContext.Current.Items[HttpContextKey] as IUnityContainer;

            if (childContainer != null)
            {
                childContainer.Dispose();
            }
        }

        protected override void DoRegister<TService, TType>(string key)
        {
            _container.RegisterType<TService, TType>();
        }

        protected override void DoRegisterSingleton<TService, TType>(string key)
        {
            _container.RegisterType<TService, TType>(new ContainerControlledLifetimeManager());
        }

        protected override object DoResolve(Type type)
        {
            return GetService(type);
        }

        protected override TService DoResolve<TService>(string key)
        {
            return (TService)GetService(typeof(TService));
        }

        protected override IEnumerable<object> DoResolveAll(Type type)
        {
            return GetServices(type);
        }

        protected override bool DoIsRegistered(Type typeToCheck)
        {
            var isRegistered = true;

            if (typeToCheck.IsInterface || typeToCheck.IsAbstract)
            {
                isRegistered = ChildContainer.IsRegistered(typeToCheck);

                if (!isRegistered && typeToCheck.IsGenericType)
                {
                    var openGenericType = typeToCheck.GetGenericTypeDefinition();

                    isRegistered = ChildContainer.IsRegistered(openGenericType);
                }
            }

            return isRegistered;
        }

        protected override bool DoIsRegistered(Type typeToCheck, string nameToCheck)
        {
            var isRegistered = true;

            if (typeToCheck.IsInterface || typeToCheck.IsAbstract)
            {
                isRegistered = ChildContainer.IsRegistered(typeToCheck, nameToCheck);

                if (!isRegistered && typeToCheck.IsGenericType)
                {
                    var openGenericType = typeToCheck.GetGenericTypeDefinition();

                    isRegistered = ChildContainer.IsRegistered(openGenericType, nameToCheck);
                }
            }

            return isRegistered;
        }

        public override string Name
        {
            get { return "PerRequestUnity"; }
        }
    }


    // [assembly: PreApplicationStartMethod(typeof(Yintai.Hangzhou.WebSupport.Ioc.PreApplicationStartCode), "PreStart")]
    public class PreApplicationStartCode
    {
        private static bool _isStarting;

        public static void PreStart()
        {
            if (!_isStarting)
            {
                _isStarting = true;

                DynamicModuleUtility.RegisterModule(typeof(RequestLifetimeHttpModule));
            }
        }
    }

    internal class RequestLifetimeHttpModule : IHttpModule
    {
        public void Init(HttpApplication context)
        {
            context.EndRequest += (sender, e) => PerRequestUnityServiceLocator.DisposeOfChildContainer();
        }

        public void Dispose()
        {
            // nothing to do here
        }
    }
}
