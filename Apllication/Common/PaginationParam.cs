
namespace Apllication.Common;

public class PaginationParam
{
    public string? OrderBy { get; set; }
    public bool OrderDescending { get; set; }
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;
}
