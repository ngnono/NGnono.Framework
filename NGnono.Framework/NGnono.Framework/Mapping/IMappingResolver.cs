using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.Framework.Mapping
{
    public interface IMappingResolver
    {
        ResolutionResult Resolve(ResolutionContext context);
    }
}
