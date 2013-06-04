

using System;
using System.Configuration;
using System.Globalization;
using System.Threading;
using NGnono.Framework.Logger;

namespace NGnono.Framework.Tools.ImageTools.Test.c
{
    /// <summary>
    /// 任务调度
    /// </summary>
    public class Task
    {
        #region fields

        public static Thread _thread;
        private readonly TimeSpan _timeSpan;
        private static ILog Logger = LoggerManager.Current();

        #endregion

        #region .ctor

        public Task()
        {
            var interval = ConfigurationManager.AppSettings["interval"].ToString(CultureInfo.InvariantCulture);

            var date = DateTime.ParseExact(interval, "HH:mm:ss", null);

            _timeSpan = new TimeSpan(date.Hour, date.Minute, date.Second);
        }

        #endregion

        #region Medthods

        public void Run()
        {
            _thread = new Thread(new ThreadStart(RunJob)) { Name = "RunJob_Thread" };
            _thread.Start();
        }

        private void RunJob()
        {
            while (true)
            {
                try
                {
                    Logger.Info("Start:" + DateTime.Now);
                    Test.Current.Run();
                    Logger.Info("End:" + DateTime.Now);
                }
                catch (Exception ex)
                {
                    //包括记录异常的内部包含异常
                    while (ex != null)
                    {
                        Logger.Error(ex);
                        ex = ex.InnerException;

                    }
                }

                Thread.Sleep(_timeSpan);
            }
        }

        public void Stop()
        {
            _thread.Abort();
        }

        #endregion
    }
}


