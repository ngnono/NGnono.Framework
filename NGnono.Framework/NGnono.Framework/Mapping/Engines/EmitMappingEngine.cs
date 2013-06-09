using EmitMapper;

namespace NGnono.Framework.Mapping.Engines
{
    /// <summary>
    /// http://emitmapper.codeplex.com/
    /// </summary>
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