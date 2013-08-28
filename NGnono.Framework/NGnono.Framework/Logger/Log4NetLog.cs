[assembly: log4net.Config.XmlConfigurator(ConfigFile = @"Configurations\Log4Net.config", Watch = true)]
namespace NGnono.Framework.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class Log4NetLog : ILog
    {
        private static readonly log4net.ILog _error = log4net.LogManager.GetLogger("ExceptionLogger");
        private static readonly log4net.ILog _info = log4net.LogManager.GetLogger("InfoLogger");
        private static readonly log4net.ILog _debug = log4net.LogManager.GetLogger("DebugLogger");
        private static readonly log4net.ILog _warn = log4net.LogManager.GetLogger("WarnLogger");
        private static readonly log4net.ILog _fatal = log4net.LogManager.GetLogger("FatalLogger");

        #region Implementation of ILog

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="obj"></param>
        public void Info(object obj)
        {
            _info.Info(obj);
        }

        /// <summary>
        /// 异常
        /// </summary>
        /// <param name="obj"></param>
        public void Exception(object obj)
        {
            Error(obj);
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="obj"></param>
        public void Debug(object obj)
        {
            _debug.Debug(obj);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="obj"></param>
        public void Warn(object obj)
        {
            _warn.Warn(obj);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="obj"></param>
        public void Error(object obj)
        {
            _error.Error(obj);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="obj"></param>
        public void Fatal(object obj)
        {
            _fatal.Fatal(obj);
        }

        #endregion
    }
}
