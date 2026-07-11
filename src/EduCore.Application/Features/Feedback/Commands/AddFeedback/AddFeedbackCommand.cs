using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Feedback.Commands.AddFeedback;

public sealed record AddFeedbackCommand(Guid CourseId, int Rating, string? Comment) : IRequest<Result<Guid>>;