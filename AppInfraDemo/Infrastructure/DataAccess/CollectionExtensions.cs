using System.Collections.Generic;

namespace DataAccess
{
    static class CollectionExtensions
    {
        public static void AddIfNotExists<T>(this ICollection<T> list, T item)
        {
            if (list.Contains(item) == false)
            {
                list.Add(item);
            }
        }
    }
}