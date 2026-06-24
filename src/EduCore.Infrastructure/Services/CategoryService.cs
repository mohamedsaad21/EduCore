using EduCore.Application.Abstracts;
using EduCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class CategoryService : ICategoryService
{
    private readonly IUnitOfWork _unitOfWork;

    public CategoryService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> IsExistsAsync(string CategoryName)
    {
        var category = await _unitOfWork.Categories.GetTableNoTracking().SingleOrDefaultAsync(c => c.NameEn == CategoryName || c.NameAr == CategoryName);
        return category != null;
    }

    public async Task<bool> IsExistsExcludeSelfAsync(Guid Id, string CategoryName)
    {
        var category = await _unitOfWork.Categories.GetTableNoTracking().SingleOrDefaultAsync(c => (c.NameEn == CategoryName || c.NameAr == CategoryName) && c.Id != Id);
        return category != null;
    }
}
