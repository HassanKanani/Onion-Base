
namespace Apllication.Common;
public static class CrudMessage
{

    public static ApiResponse<bool> CreateSuccess(string entityName)
        => ApiResponse<bool>.CreateSuccessResponse(true, $"{entityName} با موفقیت اضافه شد");

    public static ApiResponse<bool> CreateFailure(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"افزودن {entityName} با خطا مواجه شد");

    public static ApiResponse<bool> UpdateSuccess(string entityName)
        => ApiResponse<bool>.CreateSuccessResponse(true, $"ویرایش {entityName} با موفقیت انجام شد");

    public static ApiResponse<bool> UpdateFailure(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"ویرایش {entityName} با خطا مواجه شد");

    public static ApiResponse<bool> DeleteSuccess(string entityName)
        => ApiResponse<bool>.CreateSuccessResponse(true, $"حذف {entityName} با موفقیت انجام شد");

    public static ApiResponse<bool> DeleteFailure(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"حذف {entityName} با خطا مواجه شد");


    public static ApiResponse<bool> NotFound(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} مورد نظر وجود ندارد");

    public static ApiResponse<bool> IdRequired(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"لطفا {entityName} مورد نظر را وارد کنید");

    public static ApiResponse<bool> Duplicate(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} قبلا ایجاد شده است");

    public static ApiResponse<bool> NotActive(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} مورد نظر غیرفعال است");

    public static ApiResponse<bool> AlreadyReserved(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} مورد نظر قبلا رزرو شده است");

    public static ApiResponse<bool> AlreadyDeleted(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} مورد نظر قبلا حذف شده است");

    public static ApiResponse<bool> AlreadyVerified(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} مورد نظر تایید شده است و امکان ویرایش وجود ندارد");

    public static ApiResponse<bool> CannotDeleteVerified(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} مورد نظر تایید شده است و امکان حذف وجود ندارد");

    public static ApiResponse<bool> CannotEdit(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{entityName} قابل ویرایش نیست");

    public static ApiResponse<bool> HasDependency(string dependencyName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"لطفا ابتدا {dependencyName} مربوط به آن را حذف کنید");

    public static ApiResponse<bool> AccessDenied(string entityName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"دسترسی شما به {entityName} محدود است");

    public static ApiResponse<bool> FileRequired(string fileName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"{fileName} بارگذاری نشده است");

    public static ApiResponse<bool> EmptyList(string listName)
        => ApiResponse<bool>.CreateErrorResponse(false, $"لیست {listName} خالی است");

    public static ApiResponse<bool> ConfirmSuccess(string entityName)
        => ApiResponse<bool>.CreateSuccessResponse(true, $"{entityName} مورد نظر با موفقیت تایید شد");

    public static ApiResponse<bool> StatusChanged(string newStatus)
        => ApiResponse<bool>.CreateSuccessResponse(true, $"وضعیت به {newStatus} تغییر کرد");

    public static ApiResponse<bool> CustomSuccess(string customMessage)
        => ApiResponse<bool>.CreateSuccessResponse(true, customMessage);

    public static ApiResponse<bool> CustomError(string customMessage)
        => ApiResponse<bool>.CreateErrorResponse(false, customMessage);

    public static ApiResponse<bool> AutoDesignSuccess(string entityName)
        => ApiResponse<bool>.CreateSuccessResponse(true, $"چیدمان {entityName} با موفقیت انجام شد");

    public static string GetMessage<T>(this ApiResponse<T> response) => response.Message;

    public static string NotFoundMessage(string entityName) => $"{entityName} مورد نظر وجود ندارد";

    public static string IdRequiredMessage(string entityName) => $"لطفا {entityName} مورد نظر را وارد کنید";

    public static string AlreadyVerifiedMessage(string entityName) => $"{entityName} مورد نظر تایید شده است";
}