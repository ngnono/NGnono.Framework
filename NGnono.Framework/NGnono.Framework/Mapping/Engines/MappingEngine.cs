
using NGnono.Framework.Mapping.Engines.Impl;

namespace NGnono.Framework.Mapping.Engines
{
    public class MappingEngine : IMappingEngine
    {
        #region IMappingEngine Members

        public TTarget Map<TSource, TTarget>(TSource source)
        {
            return MappingBuilder<TSource, TTarget>.Map(source);
        }

        public TTarget Map<TSource, TTarget>(TSource source, TTarget target)
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
