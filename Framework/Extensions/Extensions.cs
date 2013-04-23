namespace Framework.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class Extensions
    {

        public static void AddRange<T>(this IEnumerable<T> collection, IEnumerable<T> range)
        {
            collection.ToList().AddRange(range);
        }
    }
}
