using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping.Engines.Impl
{
    public class PlainObjectMappingRunner : IMappingRunner
    {
        #region IMappingRunner Members

        public ResolutionResult Map(ResolutionContext context)
        {
            var result = new ResolutionResult(context);

            foreach (var resolver in AllResolvers())
            {
                result.MemberBindings.AddRange(resolver.Resolve(context).MemberBindings);
            }

            return result;
        }

        public Func<List<IMappingResolver>> AllResolvers
        {
            get
            {
                return () => new List<IMappingResolver> 
				{
					new PropertyMappingResolver(),
					new FieldMappingResolver()
				};
            }
        }

        #endregion
    }
}
