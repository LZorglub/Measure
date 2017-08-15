using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Afk.Measure
{
    /// <summary>
    /// Provides functions for multiplatform
    /// </summary>
    class MultiPlatform
    {
        /// <summary>
        /// Gets the current assembly
        /// </summary>
        /// <returns></returns>
        public static Assembly GetCurrentAssembly()
        {
#if NETSTANDARD
            return typeof(MultiPlatform).GetTypeInfo().Assembly;
#else
            return Assembly.GetExecutingAssembly();
#endif
        }
    }
}
