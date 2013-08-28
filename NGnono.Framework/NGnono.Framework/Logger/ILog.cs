namespace NGnono.Framework.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="obj"></param>
        void Info(object obj);

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="obj"></param>
        void Debug(object obj);

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="obj"></param>
        void Warn(object obj);

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="obj"></param>
        void Error(object obj);

        /// <summary>
        /// 致命的
        /// </summary>
        /// <param name="obj"></param>
        void Fatal(object obj);
    }
}