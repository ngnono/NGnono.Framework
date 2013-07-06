using System.Collections.Generic;
using NGnono.Framework.Models;

namespace NGnono.Framework.Data
{
    public interface IRepository<out TEntity, in TKey>
        where TEntity : BaseEntity
    {
        /// <summary>
        /// 全部
        /// </summary>
        /// <returns></returns>
        IEnumerable<TEntity> FindAll();

        /// <summary>
        /// 查找key
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        TEntity GetItem(TKey key);
    }
}
