using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NGnono.Framework.Extension
{
    /// <summary>
    /// 
    /// </summary>
    public static class EnumerableExtension
    {
        /// <summary>
        /// custom Extension methods  集合a根据条件在集合b中的元素 并返回
        /// </summary>
        /// <param name="source"></param>
        /// <param name="other"></param>
        /// <param name="predicate"></param>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TOther"></typeparam>
        /// <returns></returns>
        public static IEnumerable<TSource> In<TSource, TOther>(this IEnumerable<TSource> source, IEnumerable<TOther> other, Func<TSource, TOther, bool> predicate)
        {
            return source.Where(s => other.Any(v => predicate(s, v))).ToList();
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public static class ListExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="val"></param>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static IList<T> TryAdd<T>(this IList<T> source, T val)
        {
            if (source == null)
            {
                source = new List<T>();
            }

            source.Add(val);

            return source;
        }


    }

    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryExtension
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryInsertKey<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key)
        {
            return source.TryInsertKey(key, default(TValue));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="defaultValue">default val</param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryInsertKey<TKey, TValue>(this Dictionary<TKey, TValue> source, TKey key, TValue defaultValue)
        {
            if (source.ContainsKey(key))
            {
                return source;
            }
            source.Add(key, defaultValue);

            return source;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="source"></param>
        /// <param name="key"></param>
        /// <param name="val"></param>
        /// <typeparam name="TKey"></typeparam>
        /// <typeparam name="TValue"></typeparam>
        /// <returns></returns>
        public static Dictionary<TKey, TValue> TryInsertKeyAndVal<TKey, TValue>(
            this Dictionary<TKey, TValue> source, TKey key, TValue val)
        {
            source.TryInsertKey(key);

            source[key] = val;

            return source;
        }
    }
}
