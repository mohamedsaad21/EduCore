using EduCore.Application.Abstracts;
using EduCore.Domain.Entities;
using EduCore.Domain.Enums;
using EduCore.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EduCore.Service.Implementation;

public class CourseService : ICourseService
{
    private readonly IUnitOfWork _unitOfWork;

    public CourseService(IUnitOfWork unitOfWork, IFileService fileService, ICurrentUserService currentUserService)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Course> GetByIdAsync(Guid Id)
    {
        return await _unitOfWork.Courses.GetTableNoTracking().Include(c => c.Instructor)
            .Include(c => c.Sections).FirstOrDefaultAsync(c => c.Id == Id);
    }

    public IQueryable<Course> GetPaginatedListAsync(CourseOrderingEnum orderBy, string? Search)
    {
        var queryable = _unitOfWork.Courses.GetTableNoTracking().Include(c => c.Category).Include(c => c.Instructor).Include(c => c.Sections).AsQueryable();
        switch (orderBy)
        {
            case CourseOrderingEnum.Title:  queryable.OrderBy(c => c.Title); break;
            case CourseOrderingEnum.Price:  queryable.OrderBy(c => c.Price); break;
            case CourseOrderingEnum.AverageRating:  queryable.OrderBy(c => c.AverageRating); break;
            case CourseOrderingEnum.NoOfStudents:  queryable.OrderBy(c => c.NoOfStudents); break;
        }
        if(Search != null)
        {
            queryable = queryable.Where(c => c.Title.Contains(Search));
        }
        return queryable;
    }

    public IQueryable<Course> GetPaginatedListByCategoryIdAsync(Guid CategoryId, CourseOrderingEnum orderBy, string? Search)
    {
        var queryable = _unitOfWork.Courses.GetTableNoTracking().Include(c => c.Category).Include(c => c.Instructor).Include(c => c.Sections).Where(c => c.CategoryId == CategoryId).AsQueryable();
        switch (orderBy)
        {
            case CourseOrderingEnum.Title: queryable.OrderBy(c => c.Title); break;
            case CourseOrderingEnum.Price: queryable.OrderBy(c => c.Price); break;
            case CourseOrderingEnum.AverageRating: queryable.OrderBy(c => c.AverageRating); break;
            case CourseOrderingEnum.NoOfStudents: queryable.OrderBy(c => c.NoOfStudents); break;
        }
        if (Search != null)
        {
            queryable = queryable.Where(c => c.Title.Contains(Search));
        }
        return queryable;
    }

    public IQueryable<Course> GetPaginatedListByInstructorIdAsync(Guid InstructorId, CourseOrderingEnum orderBy, string? Search)
    {
        var queryable = _unitOfWork.Courses.GetTableNoTracking().Include(c => c.Category).Include(c => c.Sections).Where(c => c.InstructorId == InstructorId).AsQueryable();
        switch (orderBy)
        {
            case CourseOrderingEnum.Title: queryable.OrderBy(c => c.Title); break;
            case CourseOrderingEnum.Price: queryable.OrderBy(c => c.Price); break;
            case CourseOrderingEnum.AverageRating: queryable.OrderBy(c => c.AverageRating); break;
            case CourseOrderingEnum.NoOfStudents: queryable.OrderBy(c => c.NoOfStudents); break;
        }
        if (Search != null)
        {
            queryable = queryable.Where(c => c.Title.Contains(Search));
        }
        return queryable;
    }
}
