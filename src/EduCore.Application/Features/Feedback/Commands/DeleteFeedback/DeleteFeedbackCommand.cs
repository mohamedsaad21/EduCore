using EduCore.Application.Bases;
using MediatR;

namespace EduCore.Application.Features.Feedback.Commands.DeleteFeedback;

public sealed record DeleteFeedbackCommand(Guid Id) : IRequest<Result>;
