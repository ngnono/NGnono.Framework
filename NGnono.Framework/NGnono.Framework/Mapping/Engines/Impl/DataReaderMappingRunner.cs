using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping.Engines.Impl
{
    public class DataReaderMappingRunner : IMappingRunner
    {
        #region IMappingRunner Members

        public ResolutionResult Map(ResolutionContext context)
        {
            throw new NotImplementedException();
        }

        public Func<List<IMappingResolver>> AllResolvers
        {
            get { throw new NotImplementedException(); }
        }

        #endregion
    }
}
