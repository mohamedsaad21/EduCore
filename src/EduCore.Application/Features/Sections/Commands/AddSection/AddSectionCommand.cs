using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Sections.Commands.AddSection;

public sealed record AddSectionCommand
    (
        string Title, 
        int Order, 
        Guid CourseId
    ) : IRequest<Result<Guid>>;