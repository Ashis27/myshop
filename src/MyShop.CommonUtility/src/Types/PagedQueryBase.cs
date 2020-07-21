namespace DShop.Common.Types
{
    public abstract class PagedQueryBase
    {
        public int PageIndex { get; protected set; }
        public int PageSize { get; protected set; }
        public string OrderBy { get; protected set; }
        public string SortOrder { get; protected set; }

        public PagedQueryBase(int pageIndex, int pageSize, string orderBy, string sortOrder)
        {
            PageIndex = pageIndex;
            PageSize = pageSize;
            OrderBy = orderBy;
            SortOrder = sortOrder;
        }
    }
}