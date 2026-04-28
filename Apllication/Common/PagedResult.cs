
namespace Apllication.Common;
public class PagedResult<T>
{
    public List<PagedItem<T>> Items { get; set; } = [];
    public int TotalCount { get; set; }
    public int PageNumber { get; set; }
    public int PageSize { get; set; }
    public bool HasNextPage { get; set; }
    public bool HasPreviousPage { get; set; }

    public PagedResult(List<T> items, int totalCount, int pageNumber, int pageSize)
    {
        Items = Convertor(items, pageNumber, pageSize);
        TotalCount = totalCount;
        PageNumber = pageNumber;
        PageSize = pageSize;
        HasNextPage = (pageNumber * pageSize) < totalCount;
        HasPreviousPage = pageNumber >= 1;
    }
    public static List<PagedItem<T>> Convertor(List<T> items, int Number, int Size)
    {
        List<PagedItem<T>> list = [];
        for (int index = 0; index < items.Count; index++)
        {
            PagedItem<T> d = new(items[index], index + 1 + ((Number - 1) * Size));
            list.Add(d);
        }
        return list;
    }
}