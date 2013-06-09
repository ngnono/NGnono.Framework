using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping.Engines.Impl
{
    public static class MapperRegistry
    {
        public static Func<List<IMappingRunner>> AllMappingRunners = () =>
        {
            return new List<IMappingRunner>
			{
				new PlainObjectMappingRunner(),
				new DataReaderMappingRunner()
			};
        };
    }
}
