using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping.Engines.Impl
{
    public interface IConfigurationProvider
    {
        List<IMappingRunner> AllMappingRunners { get; }
        IMappingRunner FindRunner(Type type);
    }
}
