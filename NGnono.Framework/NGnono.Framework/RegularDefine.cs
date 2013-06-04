using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NGnono.Framework
{
    public class RegularDefine
    {
        /// <summary>
        /// 金额正则，可以带-号，小数点后1～2位小数
        /// </summary>
        public const string Money = @"^(-?\d+)(\.\d{1,2})?$";


    }
}
