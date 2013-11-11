using System.Diagnostics;
using NGnono.Framework.Factory;

namespace NGnono.Framework.Process
{
    /// <summary>
    /// CMD处理 代理
    /// 需要足够的可执行权限，建议用win service方式
    /// </summary>
    public class ProcessExecuteManager : IProcessExecuteProvider
    {
        private readonly BaseProcessExecuteFactory _factory;

        private readonly IProcessExecuteProvider _provider;

        private static ProcessExecuteManager _instance;

        private static readonly object AsyncObj = new object();

        private ProcessExecuteManager()
            : this(new DefaultProcessExecuteFactory())
        {
        }

        private ProcessExecuteManager(BaseProcessExecuteFactory factory)
        {
            _factory = factory;
            _provider = _factory.Create(null);
        }

        /// <summary>
        /// 单例
        /// </summary>
        public static ProcessExecuteManager Current
        {
            get
            {
                if (_instance == null)
                {
                    lock (AsyncObj)
                    {
                        if (_instance == null)
                        {
                            // ReSharper disable PossibleMultipleWriteAccessInDoubleCheckLocking
                            _instance = new ProcessExecuteManager();
                            // ReSharper restore PossibleMultipleWriteAccessInDoubleCheckLocking
                        }
                    }
                }

                return _instance;
            }
        }

        /// <summary>
        /// 执行
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="fileArgs"></param>
        public void Exectue(string exePath, string fileArgs)
        {
            _provider.Exectue(exePath, fileArgs);
        }

        /// <summary>
        /// 执行并返回信息
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="fileArgs"></param>
        /// <returns></returns>
        public string ExectueReturn(string exePath, string fileArgs)
        {
            return _provider.ExectueReturn(exePath, fileArgs);
        }
    }

    internal abstract class BaseProcessExecuteFactory : IFactory<string, IProcessExecuteProvider>
    {
        public abstract IProcessExecuteProvider Create(string opts);
    }

    internal class DefaultProcessExecuteFactory : BaseProcessExecuteFactory
    {
        private IProcessExecuteProvider _provider;

        public DefaultProcessExecuteFactory()
        {
        }

        public DefaultProcessExecuteFactory(IProcessExecuteProvider provider)
        {
            _provider = provider;
        }

        public override IProcessExecuteProvider Create(string opts)
        {
            return _provider ?? (_provider = new ProcessExecuteProvider());
        }
    }

    /// <summary>
    /// CMD 处理器
    /// </summary>
    public interface IProcessExecuteProvider
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="fileArgs"></param>
        void Exectue(string exePath, string fileArgs);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="exePath"></param>
        /// <param name="fileArgs"></param>
        /// <returns></returns>
        string ExectueReturn(string exePath, string fileArgs);
    }

    internal class ProcessExecuteProvider : IProcessExecuteProvider
    {
        public void Exectue(string exePath, string fileArgs)
        {
            CallProcess(exePath, fileArgs);
        }

        public string ExectueReturn(string exePath, string fileArgs)
        {
            return CallProcessAndReturn(exePath, fileArgs);
        }

        #region methods

        private static void CallProcess(string exePath, string fileArgs)
        {
            var startInfo = new ProcessStartInfo
            {
                Arguments = fileArgs,
                FileName = exePath,
                UseShellExecute = false,
                CreateNoWindow = false,
                RedirectStandardOutput = true
            };

            using (var exeProcess = System.Diagnostics.Process.Start(startInfo))//Process.Start(System.IO.Path.Combine(pathImageMagick,appImageMagick),fileArgs))
            {
                exeProcess.WaitForExit();
                exeProcess.Close();
            }
        }

        private static string CallProcessAndReturn(string exePath, string fileArgs)
        {
            string result;
            using (var pro = new System.Diagnostics.Process())
            {
                pro.StartInfo.UseShellExecute = false;
                pro.StartInfo.ErrorDialog = false;
                pro.StartInfo.RedirectStandardError = true;

                pro.StartInfo.FileName = exePath;
                pro.StartInfo.Arguments = fileArgs;

                pro.Start();

                using (var errorreader = pro.StandardError)
                {
                    pro.WaitForExit();

                    result = errorreader.ReadToEnd();
                }
            }

            return result;
        }

        #endregion
    }
}
