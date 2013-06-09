namespace NGnono.Framework.Caching
{
    /// <summary>
    /// 
    /// </summary>
    public interface ICachingFactory
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        ICache Create();

        /// <summary>
        /// 
        /// </summary>
        /// <param name="provider"></param>
        void Set(ICache provider);
    }
}