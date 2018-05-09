using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace LinqExamples.Commons
{
    public static class EnumerableExtensions
    {
        public static void Log<T>(this IEnumerable<T> items)
        {
            var log = items.ToList();

            foreach (var item in log)
            {

                Debug.Write(" " + item);
            }
        }

        public static void Log<T>(this T item)
        {
            Debug.Write(" " + item);
        }
    }

}
