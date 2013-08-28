namespace NGnono.Framework.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class LoggerManager
    {
        private static readonly ILog Log;

        static LoggerManager()
        {
            Log = new CommonLogging();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static ILog Current()
        {
            return Log;
        }
    }
}