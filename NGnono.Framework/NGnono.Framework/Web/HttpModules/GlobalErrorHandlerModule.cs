using System;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Web;
using NGnono.Framework.Extension;
using NGnono.Framework.Logger;
using NGnono.Framework.Models;
using NGnono.Framework.Utility;

namespace NGnono.Framework.Web.HttpModules
{
    public class GlobalErrorHandlerModule : IHttpModule
    {
        #region fields

        private static bool hasInitilized;
        private static readonly object syncRoot = new object();
        private static string eventSourceName;
        private static int unhandledExceptionCount;
        private static readonly ILog _log = LoggerManager.Current();

        #endregion

        #region IHttpModule Members

        public void Dispose()
        {
        }

        public void Init(HttpApplication context)
        {
            //ע�����ȫ�ִ���ļ�¼
            context.Error += OnError;

            #region ��¼UnhandledException

            //ʹ��Double-Check���Ʊ�֤�ڶ��̲߳�����ֻע��һ��UnhandledException�����¼�
            if (!hasInitilized)
            {
                lock (syncRoot)
                {
                    if (!hasInitilized)
                    {
                        //1. ����.net��ϰ�ߣ���Ȼ���Ƚ�������д�뵽ϵͳ��EventLog��
                        string webenginePath = Path.Combine(RuntimeEnvironment.GetRuntimeDirectory(), "webengine.dll");
                        //ͨ��webengine.dll������asp.net�İ汾��eventlog��������asp.net+�汾����
                        if (!File.Exists(webenginePath))
                        {
                            throw new Exception(String.Format(CultureInfo.InvariantCulture, "Failed to locate webengine.dll at '{0}'.  This module requires .NET Framework 2.0.", webenginePath));
                        }

                        FileVersionInfo ver = FileVersionInfo.GetVersionInfo(webenginePath);
                        eventSourceName = string.Format(CultureInfo.InvariantCulture, "ASP.NET {0}.{1}.{2}.0", ver.FileMajorPart, ver.FileMinorPart, ver.FileBuildPart);

                        if (!EventLog.SourceExists(eventSourceName))
                        {
                            throw new Exception(String.Format(CultureInfo.InvariantCulture, "There is no EventLog source named '{0}'. This module requires .NET Framework 2.0.", eventSourceName));
                        }

                        //�ڳ�����������ݼ�¼����
                        AppDomain.CurrentDomain.UnhandledException += (o, e) =>
                                                                          {
                                                                              if (Interlocked.Exchange(ref unhandledExceptionCount, 1) != 0)
                                                                                  return;

                                                                              string appId = (string)AppDomain.CurrentDomain.GetData(".appId");
                                                                              appId = appId ?? "No-appId";

                                                                              Exception currException;
                                                                              StringBuilder sb = new StringBuilder();
                                                                              sb.AppendLine(appId);
                                                                              for (currException = (Exception)e.ExceptionObject; currException != null; currException = currException.InnerException)
                                                                              {
                                                                                  sb.AppendFormat("{0}\n\r", currException.ToString());
                                                                                  _log.Error(currException);
                                                                              }

                                                                              EventLog eventLog = new EventLog { Source = eventSourceName };
                                                                              eventLog.WriteEntry(sb.ToString(), EventLogEntryType.Error);
                                                                          };

                        //��ʼ�������ø�ֵΪtrue��֤���ټ���ע���¼�
                        hasInitilized = true;
                    }
                }
            }

            #endregion
        }

        #endregion

        #region Methods

        /// <summary>
        /// ��¼asp.netδ������쳣
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private static void OnError(object sender, EventArgs e)
        {
            HttpContext context = HttpContext.Current;
            if (context == null) return;

            var exception = context.Server.GetLastError();
            if (exception == null) return;


            string message = exception.Message;

            var httpException = exception as HttpException;

            int statusCode = 404;
            if (httpException != null)
            {
                statusCode = httpException.GetHttpCode();
            }

            //������¼�쳣���ڲ������쳣
            while (exception != null)
            {
                _log.Error("Global:");
                _log.Error(exception);
                exception = exception.InnerException;
            }

            context.Server.ClearError();
            context.Response.TrySkipIisCustomErrors = true;

            //���������Ϣ

            var format = context.Request[Define.Format];

            if (String.IsNullOrEmpty(format))
            {
                format = String.Empty; // ���Ϊ�գ�����ʹ��Ĭ��ֵ
            }
            var response = String.Empty;
            var result = new ExecuteResult()
                             {
                                 Message = "����������ά�����Ժ����ԣ�",
                                 StatusCode = StatusCode.InternalServerError
                             };
            switch (format.ToLower())
            {
                case Define.Json:
                    response = Utils.DataContractToJson(result);
                    context.Response.ContentType = "application/json; charset=utf-8";
                    break;
                case Define.Xml:
                    response = result.ToXml();
                    context.Response.ContentType = "text/xml; charset=utf-8";
                    break;
                default:
                    response = Utils.DataContractToJson(result);
                    context.Response.ContentType = "text/html; charset=utf-8";
                    break;
            }

            context.Response.ClearHeaders();
            context.Response.Clear();
            context.Response.StatusCode = 200;

            context.Response.Write(response);
        }

        #endregion
    }
}