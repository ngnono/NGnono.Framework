using System;
using System.Globalization;
using System.Web.Mvc;

namespace NGnono.Framework.Web.Mvc.Binders
{
    /// <summary>
    /// ʹ��ģ�Ͱ��� Attribute
    /// </summary>
    [AttributeUsage(AttributeTargets.Parameter, AllowMultiple = false, Inherited = false)]
    public class UseBinderAttribute : CustomModelBinderAttribute
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="UseBinderAttribute"/> class.
        /// </summary>
        /// <param name="binderType">
        /// The binder type.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// ����Null����
        /// </exception>
        /// <exception cref="ArgumentException">
        /// �Զ��������δʵ�ֽӿ�IModelBinder
        /// </exception>
        public UseBinderAttribute(Type binderType)
        {
            if (binderType == null)
            {
                throw new ArgumentNullException("binderType");
            }

            if (!typeof(IModelBinder).IsAssignableFrom(binderType))
            {
                var message = String.Format(CultureInfo.CurrentCulture, "�Զ��������{0}δʵ�ֽӿ�IModelBinder", binderType.FullName);
                throw new ArgumentException(message, "binderType");
            }

            this.BinderType = binderType;
        }

        /// <summary>
        /// Gets BinderType.
        /// </summary>
        public Type BinderType { get; private set; }

        /// <summary>
        /// ��ʶ����form querystring etc..
        /// </summary>
        public string KeyName { get; set; }

        /// <summary>
        /// �Ƿ������
        /// </summary>
        public bool IsCanMissing { get; set; }

        /// <summary>
        /// Retrieves the associated model binder.
        /// </summary>
        /// <returns>
        /// A reference to an object that implements the <see cref="T:System.Web.Mvc.IModelBinder"/> interface.
        /// </returns>
        public override IModelBinder GetBinder()
        {
            try
            {
                var modelBinder = (IModelBinder)DependencyResolver.Current.GetService(this.BinderType);
                var asModelBinderBase = modelBinder as ModelBinderBase;
                if (asModelBinderBase == null)
                {
                    return modelBinder;
                }

                asModelBinderBase.KeyName = this.KeyName;
                asModelBinderBase.IsCanMissing = this.IsCanMissing;

                return asModelBinderBase;
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(String.Format(CultureInfo.CurrentCulture, "��ȡģ�Ͱ���{0}ʧ��", this.BinderType.FullName), ex);
            }
        }
    }
}