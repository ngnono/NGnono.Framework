﻿using System;
using System.Collections.Generic;

namespace NGnono.Framework.Caching.Provider
{
    internal class NoCacheProvider : BaseCacheProvider
    {
        public override bool GetItem(string key, out object value)
        {
            value = null;

            return true;
        }

        public override void PutItem(string key, object value, IEnumerable<string> dependentEntitySets, TimeSpan slidingExpiration,
                                     DateTime absoluteExpiration)
        {

        }

        public override void InvalidateSets(IEnumerable<string> entitySets)
        {

        }

        public override void InvalidateItem(string key)
        {

        }

        public override void Clear()
        {

        }
    }
}