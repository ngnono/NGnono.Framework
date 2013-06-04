using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.Framework.ServiceLocation
{
    /// <summary>
    /// 提供不同的DI容器的Adapter实例
    /// </summary>
    public delegate IServiceLocator ServiceLocatorProvider();
}
