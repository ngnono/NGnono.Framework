using System.Runtime.Serialization;

namespace NGnono.Framework.Models
{
    /// <summary>
    ///     执行结果
    /// </summary>
    [DataContract(Name = "result")]
    public class ExecuteResult
    {
        #region .ctor

        /// <summary>
        /// </summary>
        public ExecuteResult()
        {
            StatusCode = StatusCode.Success;
            Message = "ok";
        }

        #endregion

        #region properties

        /// <summary>
        ///     状态码
        /// </summary>
        [DataMember(Name = "statusCode", Order = 2)]
        public StatusCode StatusCode { get; set; }

        /// <summary>
        ///     是否成功
        /// </summary>
        [DataMember(Name = "isSuccessful", Order = 1)]
        public bool IsSuccess
        {
            get { return StatusCode == StatusCode.Success; }
        }

        /// <summary>
        ///     信息
        /// </summary>
        [DataMember(Name = "message", Order = 3)]
        public string Message { get; set; }

        #endregion
    }

    /// <summary>
    ///     泛型的执行结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    [DataContract(Name = "result")]
    public class ExecuteResult<T> : ExecuteResult
    {
        #region fields

        #endregion

        #region .ctor

        /// <summary>
        /// 
        /// </summary>
        /// <param name="data"></param>
        public ExecuteResult(T data)
        {
            Data = data;
        }

        /// <summary>
        /// 
        /// </summary>
        public ExecuteResult()
            : this(default(T))
        {
        }

        #endregion

        #region properties

        /// <summary>
        ///     返回数据
        /// </summary>
        [DataMember(Name = "data")]
        public T Data { get; set; }

        #endregion

        #region methods

        #endregion
    }
}