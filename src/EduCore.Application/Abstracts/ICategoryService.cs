namespace EduCore.Application.Abstracts;

public interface ICategoryService
{
    Task<bool> IsExistsAsync(string CategoryName);
    Task<bool> IsExistsExcludeSelfAsync(Guid Id, string CategoryName);
}
