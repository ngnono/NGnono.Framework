using Common.Logging;

namespace NGnono.Framework.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class CommonLogging : ILog
    {
        private static readonly Common.Logging.ILog _log = LogManager.GetCurrentClassLogger();

        public void Info(object obj)
        {
            _log.Info(obj);
        }

        public void Debug(object obj)
        {
            _log.Debug(obj);
        }

        public void Warn(object obj)
        {
            _log.Warn(obj);
        }

        public void Error(object obj)
        {
            _log.Error(obj);
        }

        public void Fatal(object obj)
        {
            _log.Fatal(obj);
        }
    }
}