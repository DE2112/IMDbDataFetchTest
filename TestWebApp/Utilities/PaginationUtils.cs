using System.Collections.Generic;
using System.Linq;

namespace TestWebApp.Utilities
{
    public static class PaginationUtils {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, int page, int pageSize) {
            return collection.Skip(page * pageSize).Take(pageSize);
        }
    }
}