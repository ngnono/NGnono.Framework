namespace NGnono.Framework.Mapping
{
    public interface IMappingEngine
    {
        TTarget Map<TSource, TTarget>(TSource source);

        TTarget Map<TSource, TTarget>(TSource source, TTarget target);
    }
}
