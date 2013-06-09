using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping.Engines.Impl
{
    public interface IMappingRunner
    {
        ResolutionResult Map(ResolutionContext context);

        Func<List<IMappingResolver>> AllResolvers { get; }
    }
}
