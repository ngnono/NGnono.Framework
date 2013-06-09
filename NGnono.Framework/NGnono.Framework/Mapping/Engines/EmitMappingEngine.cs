using EmitMapper;

namespace NGnono.Framework.Mapping.Engines
{
    internal class EmitMappingEngine : IMappingEngine
    {
        private static readonly ObjectMapperManager EmitMapper = ObjectMapperManager.DefaultInstance;

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return EmitMapper.GetMapper<TSource, TTarget>().Map(source);
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return EmitMapper.GetMapper<TSource, TTarget>().Map(source, target);
        }
    }
}