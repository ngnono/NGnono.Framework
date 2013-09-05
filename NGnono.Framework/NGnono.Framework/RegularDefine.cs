
namespace NGnono.Framework
{
    /// <summary>
    /// 
    /// </summary>
    public class RegularDefine
    {
        /// <summary>
        /// 金额正则，可以带-号，小数点后1～2位小数
        /// </summary>
        public const string Money = @"^(-?\d+)(\.\d{1,2})?$";
    }
}
