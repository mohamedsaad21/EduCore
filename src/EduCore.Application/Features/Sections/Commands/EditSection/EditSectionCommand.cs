using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Sections.Commands.EditSection;

public sealed record EditSectionCommand
    (
        Guid Id,
        string Title, 
        int Order
    ) : IRequest<Result>;