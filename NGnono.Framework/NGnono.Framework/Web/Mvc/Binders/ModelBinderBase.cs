﻿using System;
using System.Web.Mvc;
using NGnono.Framework.Logger;
using NGnono.Framework.ServiceLocation;

namespace NGnono.Framework.Web.Mvc.Binders
{
    /// <summary>
    /// 模型绑定器抽象基类 
    /// </summary>
    public abstract class ModelBinderBase : IModelBinder
    {
        protected ModelBinderBase()
        {
            Logger = ServiceLocator.Current.Resolve<ILog>();
        }

        protected ILog Logger { get; set; }

        /// <summary>
        /// 标识后缀
        /// </summary>
        private string _idSuffix = "id";

        /// <summary>
        /// 参数后缀
        /// </summary>
        public virtual string IdSuffix
        {
            get { return this._idSuffix; }
            set { this._idSuffix = value; }
        }

        /// <summary>
        /// 参数名称
        /// </summary>
        public virtual string KeyName { get; set; }

        /// <summary>
        /// 参数前缀
        /// </summary>
        public virtual string IdPrefix { get; set; }

        /// <summary>
        /// 是否允许空
        /// </summary>
        public bool IsCanMissing { get; set; }

        /// <summary>
        /// 绑定模型
        /// 从Action方法的参数中获得模型标识(主键)，传递给实现类的GetModelInstance方法
        /// </summary>
        /// <returns>
        /// The bound value.
        /// </returns>
        /// <param name="controllerContext">The controller context.</param><param name="bindingContext">The binding context.</param>
        public virtual object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            var keyForModelId = String.IsNullOrEmpty(this.KeyName) ? this.IdPrefix + bindingContext.ModelName + this.IdSuffix : this.KeyName;
            var v = bindingContext.ValueProvider.GetValue(keyForModelId);
            if (v == null)
            {
                // 当允许不提供值时则返回 null
                if (this.IsCanMissing) return null;
                throw new ArgumentNullException(keyForModelId, "未提供参数");
            }

            var modelId = v.AttemptedValue;
            if (String.IsNullOrWhiteSpace(modelId))
            {
                throw new ArgumentNullException(keyForModelId, String.Format("绑定类型时需要参数{0},但未提供，请检查form,querystring中是否存在", keyForModelId));
            }

            return this.GetModelInstance(modelId);
        }

        /// <summary>
        /// 根据模型标识获取模型实例
        /// </summary>
        /// <param name="modelId">
        /// 模型标识
        /// </param>
        /// <returns>
        /// 模型实例
        /// </returns>
        protected abstract object GetModelInstance(string modelId);
    }
}
