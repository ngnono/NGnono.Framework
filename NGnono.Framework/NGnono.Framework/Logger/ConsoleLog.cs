using System;

namespace NGnono.Framework.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public class ConsoleLog : ILog
    {
        #region Implementation of ILog

        /// <summary>
        /// 信息
        /// </summary>
        /// <param name="obj"></param>
        public void Info(object obj)
        {
            Console.WriteLine(obj);
        }

        /// <summary>
        /// 调试信息
        /// </summary>
        /// <param name="obj"></param>
        public void Debug(object obj)
        {
            Console.WriteLine(obj);
        }

        /// <summary>
        /// 警告
        /// </summary>
        /// <param name="obj"></param>
        public void Warn(object obj)
        {
            Console.WriteLine(obj);
        }

        /// <summary>
        /// 错误
        /// </summary>
        /// <param name="obj"></param>
        public void Error(object obj)
        {
            Console.WriteLine(obj);
        }

        public void Fatal(object obj)
        {
            Console.WriteLine(obj);
        }

        #endregion
    }
}