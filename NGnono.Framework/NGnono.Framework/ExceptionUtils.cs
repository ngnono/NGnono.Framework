﻿using System;

namespace NGnono.Framework
{
    public class ExceptionUtils
    {
        #region fields

        #endregion

        #region .ctor

        #endregion

        #region properties

        #endregion

        #region methods

        internal static void CheckOnNull(object value, string parameter)
        {
            if (value == null)
                throw new ArgumentNullException(parameter);
        }

        #endregion
    }
}
