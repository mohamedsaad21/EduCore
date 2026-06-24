using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.CourseProgress.Commands.ChangeContentCompletionStatus;

public sealed record ChangeContentCompletionStatusCommand(Guid ContentId, bool IsCompleted) : IRequest<Result>;