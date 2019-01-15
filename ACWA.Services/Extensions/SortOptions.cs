using System;
using System.Linq.Expressions;

namespace ACWA.Services.Extensions
{
    public class SortOptions<T>
    {
        public Expression<Func<T, object>> Predicate { private set; get; }
        public SortTypes SortType { private set; get; }

        public SortOptions(Expression<Func<T, object>> predicate, SortTypes sortType)
        {
            Predicate = predicate;
            SortType = sortType;
        }
    }
}