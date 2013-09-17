using System;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace NGnono.Framework.Models
{
    /// <summary>
    ///     可分页的
    /// </summary>
    public interface IPagerable
    {
        /// <summary>
        ///     页码(从1起始)
        /// </summary>
        int Index { get; }

        /// <summary>
        ///     页大小
        /// </summary>
        int Size { get; }

        /// <summary>
        ///     总页数
        /// </summary>
        int TotalPaged { get; }

        /// <summary>
        ///     总记录数
        /// </summary>
        int TotalCount { get; }
    }

    /// <summary>
    ///     可分页迭代器
    /// </summary>
    /// <typeparam name="T">类型</typeparam>
    public interface IPagerEnumerable<out T> : IEnumerable<T>, IPagerable
    {
    }

    /// <summary>
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class PagerInfo<T> : List<T>, IPagerEnumerable<T>
    {
        #region fields

        #endregion

        #region .ctor

        /// <summary>
        /// </summary>
        public PagerInfo()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        public PagerInfo(PagerRequest request)
            : this(request, 0)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="request"></param>
        /// <param name="totalCount"></param>
        public PagerInfo(PagerRequest request, int totalCount)
        {
            Index = request.PageIndex;
            Size = request.PageSize;
            TotalCount = totalCount;
        }

        #endregion

        #region properties

        /// <summary>
        ///     是否存在分页
        /// </summary>
        [DataMember(Name = "ispaged", Order = 5)]
        public bool IsPaged
        {
            get { return Size < TotalCount; }
        }

        /// <summary>
        ///     索引
        /// </summary>
        [DataMember(Name = "pageindex", Order = 1)]
        public int Index { get; set; }

        /// <summary>
        ///     大小
        /// </summary>
        [DataMember(Name = "pagesize", Order = 2)]
        public int Size { get; set; }

        /// <summary>
        ///     总数据量
        /// </summary>
        [DataMember(Name = "totalcount", Order = 3)]
        public int TotalCount { get; set; }

        /// <summary>
        ///     总页数
        /// </summary>
        [DataMember(Name = "totalpaged", Order = 4)]
        public int TotalPaged
        {
            get { return (int)Math.Ceiling(TotalCount / (double)Size); }
        }

        #endregion

        #region methods

        #endregion
    }

    /// <summary>
    ///     分页请求
    /// </summary>
    [DataContract]
    public class PagerRequest
    {
        private readonly int _maxPageSize;

        /// <summary>
        ///     local pageNumber
        /// </summary>
        private int _pageIndex;

        /// <summary>
        ///     local pageSize
        /// </summary>
        private int _pageSize;

        /// <summary>
        /// </summary>
        public PagerRequest()
            : this(40)
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="maxPageSize"></param>
        public PagerRequest(int maxPageSize)
        {
            _maxPageSize = maxPageSize;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PagerRequest" /> class.
        /// </summary>
        /// <param name="pageNumber">
        ///     The page number.
        /// </param>
        /// <param name="pageSize">
        ///     The page size.
        /// </param>
        public PagerRequest(int pageNumber, int pageSize)
            : this(pageNumber, pageSize, 40)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="PagerRequest" /> class.
        /// </summary>
        /// <param name="pageNumber">
        ///     The page number.
        /// </param>
        /// <param name="pageSize">
        ///     The page size.
        /// </param>
        /// <param name="maxPageSize"> </param>
        public PagerRequest(int pageNumber, int pageSize, int maxPageSize)
            : this(maxPageSize)
        {
            PageSize = pageSize;
            PageIndex = pageNumber;
        }

        /// <summary>
        ///     页大小
        /// </summary>
        [DataMember]
        public int PageSize
        {
            get { return _pageSize; }

            private set { _pageSize = (value < 1 ? 1 : (value > _maxPageSize ? _maxPageSize : value)); }
        }

        /// <summary>
        ///     页码
        /// </summary>
        [DataMember]
        public int PageIndex
        {
            get { return _pageIndex; }

            private set { _pageIndex = value < 1 ? 1 : value; }
        }
    }
}