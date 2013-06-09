namespace NGnono.Framework.Mapping.Engines
{
    internal class AutoMappingEngine : IMappingEngine
    {
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source, target);
        }
    }
}