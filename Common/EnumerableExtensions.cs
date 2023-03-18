using System;
using System.Collections.Generic;

namespace ActiveWindow.Common
{
    public static class EnumerableExtensions
    {
        public static void Do<T>(this IEnumerable<T> sequence, Action<T> action)
        {
            foreach (T obj in sequence)
                action(obj);
        }
    }
}
