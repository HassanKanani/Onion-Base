
namespace Domain.Common;

public interface IReportEntity
{
     bool IsActive { get; set; }
     bool IsDeleted { get; set; }
     DateTime CreateOn { get; set; }
     DateTime? ModifiedOn { get; set; }
     string? CreateBy { get; set; }
     string? ModifiedBy { get; set; }
}
