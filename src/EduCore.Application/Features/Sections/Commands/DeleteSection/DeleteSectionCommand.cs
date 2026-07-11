using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Sections.Commands.DeleteSection;

public sealed record DeleteSectionCommand(Guid Id) : IRequest<Result>;