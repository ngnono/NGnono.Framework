using System;
using System.Linq;
using System.Linq.Expressions;
using NGnono.Framework.Models;

namespace NGnono.Framework.Data.EF
{
    /// <summary>
    /// IRepository�ӿ�
    /// </summary>
    /// <typeparam name="T">����ʵ��</typeparam>
    public interface IEFRepository<T> where T : BaseEntity
    {
        /// <summary>        
        /// Get the total objects count.        
        /// </summary>        
        int Count { get; }

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="filter">����</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null);

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <typeparam name="Key">����</typeparam>
        /// <param name="filter">����</param>
        /// <param name="total">ɸѡ�󷵻ؼ�¼��</param>
        /// <param name="index">ָ��ҳ������</param>
        /// <param name="size">ָ��ҳ������</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50);

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <typeparam name="Key">����</typeparam>
        /// <param name="filter">����</param>
        /// <param name="total">ɸѡ�󷵻ؼ�¼��</param>
        /// <param name="index">ָ��ҳ������</param>
        /// <param name="size">ָ��ҳ������</param>
        /// <param name="orderBy">����</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter, out int total, int index = 0, int size = 50, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null);

        /// <summary>
        /// ��ѯ
        /// </summary>
        /// <param name="filter">����</param>
        /// <param name="orderBy">����</param>
        /// <param name="includeProperties">��������</param>
        /// <returns></returns>
        IQueryable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "");

        /// <summary>
        /// ��ȡ��������
        /// </summary>
        /// <returns></returns>
        IQueryable<T> GetAll();

        /// <summary>
        /// ����ID��ȡһ����¼
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find(object id);

        /// <summary>
        /// �鿴�Ƿ����ĳ�������¼�¼
        /// </summary>
        /// <param name="filter">����</param>
        /// <returns></returns>
        bool Contains(Expression<Func<T, bool>> filter);

        /// <summary>
        /// Find object by keys
        /// </summary>
        /// <param name="keys">Specified the search keys</param>
        /// <returns></returns>
        T Find(params object[] keys);

        /// <summary>
        /// ������������
        /// </summary>
        /// <param name="filter">����</param>
        /// <returns></returns>
        T Find(Expression<Func<T, bool>> filter);

        /// <summary>
        /// ����
        /// </summary>
        /// <param name="entity">Ҫ�����ʵ��</param>
        /// <returns name="T">���ظ��º��ʵ��</returns>
        T Insert(T entity);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="entitys">ʵ��</param>
        /// <returns></returns>
        IQueryable<T> BatchInsert(params T[] entitys);

        /// <summary>
        /// ����IDɾ��
        /// </summary>
        /// <param name="id">����ID��ɾ��</param>
        void Delete(object id);

        /// <summary>
        /// ����ʵ��ɾ��
        /// </summary>
        /// <param name="entity">Ҫɾ����ʵ��</param>
        void Delete(T entity);

        /// <summary>        
        /// ��������ɾ��.        
        /// </summary>        
        /// <param name="filter">ɾ������</param> 
        /// <returns>int</returns>
        int Delete(Expression<Func<T, bool>> filter);

        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="entity">Ҫ���µ�ʵ��</param>
        void Update(T entity);

        /// <summary>
        /// ����
        /// </summary>
        T Create();
    }
}