using System.Collections.Generic;
using System.Linq;

namespace DShop.Common.Types
{
    public class PaginatedResultBase<TEntity> where TEntity : class
    {
        public int PageIndex { get; private set; }

        public int PageSize { get; private set; }

        public long Count { get; private set; }

        public IEnumerable<TEntity> Items { get; private set; }

        public PaginatedResultBase(int pageIndex, int pageSize,long count, IEnumerable<TEntity> data)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            Count = count;
            Items = data;
        }
    }
}