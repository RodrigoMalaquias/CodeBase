namespace CodeBase.Shared.Extensions
{
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> objects)
        {
            return objects == null || !objects.Any();
        }
    }
}
