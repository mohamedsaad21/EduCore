using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using EduCore.Domain.Enums;
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

    public async Task<Section> GetByIdAsync(Guid? Id)
    {
        return await _unitOfWork.Sections.GetTableNoTracking().FirstOrDefaultAsync(x => x.Id == Id);
    }

    public IQueryable<Section> GetCourseSectionsPaginatedList(Guid CourseId, SectionOrderingEnum OrderBy, string? Search)
    {
        var queryable = _unitOfWork.Sections.GetTableNoTracking().Where(x => x.CourseId == CourseId).AsQueryable();
        switch (OrderBy)
        {
            case SectionOrderingEnum.Title: queryable.OrderBy(x => x.Title); break;
            case SectionOrderingEnum.Order: queryable.OrderBy(x => x.Order); break;
        }
        if (!string.IsNullOrEmpty(Search))
        {
            queryable = queryable.Where(x => x.Title.Contains(Search));
        }
        return queryable;
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
