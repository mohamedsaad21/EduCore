using EduCore.Application.Abstracts;
using EduCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class SectionService : ISectionService
{
    private readonly IUnitOfWork _unitOfWork;

    public SectionService(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<bool> IsSectionOrderExists(Guid CourseId, int Order)
    {
        var section =  await _unitOfWork.Sections.GetTableNoTracking().Where(x => x.CourseId == CourseId && x.Order == Order).SingleOrDefaultAsync();
        return section != null;
    }

    public async Task<bool> IsSectionTitleExists(Guid CourseId, string Title)
    {
        var section = await _unitOfWork.Sections.GetTableNoTracking().Where(x => x.CourseId == CourseId && x.Title.ToLower() == Title.ToLower()).SingleOrDefaultAsync();
        return section != null;
    }
}
