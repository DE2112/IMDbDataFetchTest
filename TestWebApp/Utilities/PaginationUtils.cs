using System.Collections.Generic;
using System.Linq;

namespace TestWebApp.Utilities
{
    public static class PaginationUtils {
        public static IEnumerable<T> Page<T>(this IEnumerable<T> collection, int pageSize, int page) {
            return collection.Skip(page * pageSize).Take(pageSize);
        }
        public static IQueryable<T> Page<T>(this IQueryable<T> collection, int pageSize, int page) {
            return collection.Skip(page * pageSize).Take(pageSize);
        }
    }
}