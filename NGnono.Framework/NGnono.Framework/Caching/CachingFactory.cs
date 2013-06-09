using System;
using NGnono.Framework.Caching.Provider;
using NGnono.Framework.Configuraton;

namespace NGnono.Framework.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public class CachingFactory : ICachingFactory
    {
        private ICache _caches;
        private readonly object _syncObj = new object();

        ICache ICachingFactory.Create()
        {
            if (_caches == null)
            {
                lock (_syncObj)
                {
                    if (_caches == null)
                    {
                        var assemblyName = ConfigManager.GetCacheProvider();
                        if (String.IsNullOrWhiteSpace(assemblyName))
                        {
                            _caches = new NoCacheProvider();
                        }
                        else
                        {
                            var assemblys = assemblyName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
                            var handler = Activator.CreateInstance(assemblys[0], assemblys[1]);
                            var obj = handler.Unwrap();
                            _caches = obj as ICache;
                        }

                    }
                }
            }

            return _caches;
        }

        void ICachingFactory.Set(ICache provider)
        {
            _caches = provider;
        }
    }
}
