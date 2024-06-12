namespace Application.Common;

public class Pagination<T>
{
    // Set the maximum amount of items in one page
    private const int MaxPageSize = 100;

    private int _pageIndex;

    private int _pageSize = 10;
    public int TotalItemCount { get; set; }

    public int PageSize
    {
        get => _pageSize;
        set => _pageSize = value > MaxPageSize ? MaxPageSize : value;
    }

    public int TotalPagesCount
    {
        get
        {
            var tmp = TotalItemCount / PageSize;
            if (TotalItemCount % PageSize == 0) return tmp;
            return tmp + 1;
        }
    }

    // Auto re-assign pageIndex
    // if pageIndex is greater than or equal to TotalPagesCount
    public int PageIndex
    {
        get => _pageIndex;
        set => _pageIndex = value >= TotalPagesCount ? TotalPagesCount - 1 : value;
    }

    public bool Next => PageIndex + 1 < TotalPagesCount;
    public bool Previous => PageIndex > 0;
    public ICollection<T> Items { get; set; }
}