using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NGnono.Framework.Models
{
    /// <summary>
    /// �ɷ�ҳ��
    /// </summary>
    public interface IPagedable
    {
        /// <summary>
        /// ҳ��(��1��ʼ)
        /// </summary>
        int Index { get; set; }

        /// <summary>
        /// ҳ��С
        /// </summary>
        int Size { get; }

        /// <summary>
        /// ��ҳ��
        /// </summary>
        int TotalPaged { get; }

        /// <summary>
        /// �ܼ�¼��
        /// </summary>
        int TotalCount { get; }
    }

    /// <summary>
    /// �ɷ�ҳ������
    /// </summary>
    /// <typeparam name="T">����</typeparam>
    public interface IPagedEnumerable<out T> : IEnumerable<T>, IPagedable
    {
    }

    //[DataContract(Name = "pager")]
    public class PagerInfo<T> : List<T>, IPagedEnumerable<T>
    {
        #region fields

        #endregion

        #region .ctor

        public PagerInfo()
        {
        }

        public PagerInfo(PagerRequest request)
            : this(request, 0)
        {
        }

        public PagerInfo(PagerRequest request, int totalCount)
        {
            this.Index = request.PageIndex;
            this.Size = request.PageSize;
            this.TotalCount = totalCount;
        }

        #endregion

        #region properties

        /// <summary>
        /// ����
        /// </summary>
        [DataMember(Name = "pageindex", Order = 1)]
        public int Index { get; set; }

        /// <summary>
        /// ��С
        /// </summary>
        [DataMember(Name = "pagesize", Order = 2)]
        public int Size { get; set; }

        /// <summary>
        /// ��������
        /// </summary>
        [DataMember(Name = "totalcount", Order = 3)]
        public int TotalCount { get; set; }

        /// <summary>
        /// ��ҳ��
        /// </summary>
        [DataMember(Name = "totalpaged", Order = 4)]
        public int TotalPaged
        {
            get
            {
                return (int)Math.Ceiling(this.TotalCount / (double)this.Size);
            }
            set { }
        }

        /// <summary>
        /// �Ƿ���ڷ�ҳ
        /// </summary>
        [DataMember(Name = "ispaged", Order = 5)]
        public bool IsPaged
        {
            get
            {
                return Size < TotalCount;
            }
            set { }
        }

        #endregion

        #region methods

        #endregion
    }

    /// <summary>
    /// ��ҳ����
    /// </summary>
    [DataContract]
    public class PagerRequest
    {
        private readonly int _maxPageSize;

        public PagerRequest()
            : this(40)
        {
        }

        public PagerRequest(int maxPageSize)
        {
            this._maxPageSize = maxPageSize;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagerRequest"/> class.
        /// </summary>
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        public PagerRequest(int pageNumber, int pageSize)
            : this(pageNumber, pageSize, 40)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="PagerRequest"/> class.
        /// </summary>
        /// <param name="pageNumber">
        /// The page number.
        /// </param>
        /// <param name="pageSize">
        /// The page size.
        /// </param>
        /// <param name="maxPageSize"> </param>
        public PagerRequest(int pageNumber, int pageSize, int maxPageSize)
            : this(maxPageSize)
        {
            this.PageSize = pageSize;
            this.PageIndex = pageNumber;
        }

        /// <summary>
        /// local pageNumber
        /// </summary>
        private int _pageIndex;

        /// <summary>
        /// local pageSize
        /// </summary>
        private int _pageSize;

        /// <summary>
        /// ҳ��С
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get
            {
                return this._pageSize;
            }

            private set
            {
                this._pageSize = (value < 1 ? 1 : (value > _maxPageSize ? _maxPageSize : value));
            }
        }

        /// <summary>
        /// ҳ��
        /// </summary>
        [DataMember]
        public int PageIndex
        {
            get
            {
                return this._pageIndex;
            }

            private set
            {
                this._pageIndex = value < 1 ? 1 : value;
            }
        }
    }
}