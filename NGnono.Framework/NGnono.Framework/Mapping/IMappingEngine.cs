namespace NGnono.Framework.Mapping
{
    /// <summary>
    /// 
    /// </summary>
    public interface IMappingEngine
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns></returns>
        TTarget Map<TSource, TTarget>(TSource source);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <returns></returns>
        TTarget Map<TSource, TTarget>(TSource source, TTarget target);

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        object GetEngineProvider();

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        string GetEngineProviderName();
    }
}
