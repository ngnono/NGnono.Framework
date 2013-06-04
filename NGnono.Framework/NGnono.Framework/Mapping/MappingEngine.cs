using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NGnono.Framework.Mapping;

namespace NGnono.Framework.Mapping
{
    public class MappingEngine : IMappingEngine
    {
        #region IMappingEngine Members

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return MappingBuilder<TSource, TTarget>.Map(source);
        }

        #endregion
    }
}
