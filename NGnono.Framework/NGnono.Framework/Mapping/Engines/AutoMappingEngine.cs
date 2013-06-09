namespace NGnono.Framework.Mapping.Engines
{
    /// <summary>
    /// https://github.com/AutoMapper/AutoMapper
    /// </summary>
    public class AutoMapperEngine : IMappingEngine
    {
        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source);
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            return AutoMapper.Mapper.Map<TSource, TTarget>(source, target);
        }

        public object GetEngineProvider()
        {
            return AutoMapper.Mapper.Engine;
        }

        public string GetEngineProviderName()
        {
            return "AutoMapper";
        }
    }
}