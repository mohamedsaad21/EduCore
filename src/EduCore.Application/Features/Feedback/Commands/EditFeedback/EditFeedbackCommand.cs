using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Feedback.Commands.EditFeedback;

public sealed record EditFeedbackCommand(Guid Id, Guid CourseId, int Rating, string? Comment) : IRequest<Result>;
