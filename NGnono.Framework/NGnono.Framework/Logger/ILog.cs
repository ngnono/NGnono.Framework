namespace NGnono.Framework.Logger
{
    /// <summary>
    /// 
    /// </summary>
    public interface ILog
    {
        /// <summary>
        /// ��Ϣ
        /// </summary>
        /// <param name="obj"></param>
        void Info(object obj);

        /// <summary>
        /// ������Ϣ
        /// </summary>
        /// <param name="obj"></param>
        void Debug(object obj);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="obj"></param>
        void Warn(object obj);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="obj"></param>
        void Error(object obj);

        /// <summary>
        /// ������
        /// </summary>
        /// <param name="obj"></param>
        void Fatal(object obj);
    }
}