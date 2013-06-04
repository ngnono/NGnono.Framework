using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping
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
