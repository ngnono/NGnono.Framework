using System.Runtime.Serialization;

namespace NGnono.Framework.Models
{
    /// <summary>
    /// ϵͳ״̬��
    /// </summary>
    [DataContract(Name = "statusCode")]
    public enum StatusCode
    {
        /// <summary>
        /// δ֪״̬
        /// </summary>
        [EnumMember]
        UnKnow = 0,

        /// <summary>
        /// �����ɹ�
        /// </summary>
        [EnumMember]
        Success = 200,

        /// <summary>
        /// �ͻ��˴���
        /// </summary>
        [EnumMember]
        ClientError = 400,

        /// <summary>
        /// δͨ����֤��
        /// </summary>
        [EnumMember]
        Unauthorized = 401,

        /// <summary>
        /// ����ʱ
        /// </summary>
        [EnumMember]
        RequestTimeout = 408,

        /// <summary>
        /// ϵͳ�ڲ�����
        /// </summary>
        [EnumMember]
        InternalServerError = 500,

        /// <summary>
        /// �����ݲ�����
        /// </summary>
        [EnumMember]
        ServiceUnavailable = 503
    }
}