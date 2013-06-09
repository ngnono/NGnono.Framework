using System;
using System.Collections.Generic;

namespace NGnono.Framework.Mapping
{
    public interface IMapper
    {
        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <returns></returns>
        TTarget Map<TSource, TTarget>(TSource source);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="engine"></param>
        /// <returns></returns>
        TTarget Map<TSource, TTarget>(TSource source, IMappingEngine engine);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="mapper"></param>
        /// <returns></returns>
        TTarget Map<TSource, TTarget>(TSource source, Func<TSource, TTarget> mapper);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="sourceCollection"></param>
        /// <returns></returns>
        IEnumerable<TTarget> Map<TSource, TTarget>(IEnumerable<TSource> sourceCollection);

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TTarget"></typeparam>
        /// <param name="source"></param>
        /// <param name="target"></param>
        /// <returns></returns>
        TTarget Map<TSource, TTarget>(TSource source, TTarget target);
    }
}