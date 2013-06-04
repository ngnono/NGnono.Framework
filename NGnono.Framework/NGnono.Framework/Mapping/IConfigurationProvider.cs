using System;
using System.Collections.Generic;
using NGnono.Framework.Mapping;

namespace NGnono.Framework.Mapping
{
    public interface IConfigurationProvider
    {
        List<IMappingRunner> AllMappingRunners { get; }
        IMappingRunner FindRunner(Type type);
    }
}
