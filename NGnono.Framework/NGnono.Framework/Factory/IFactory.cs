namespace NGnono.Framework.Factory
{
    /// <summary>
    /// 工厂
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IFactory<in TIn, out TOut>
    {
        /// <summary>
        /// 创建
        /// </summary>
        /// <param name="opts"></param>
        /// <returns></returns>
        TOut Create(TIn opts);
    }
}