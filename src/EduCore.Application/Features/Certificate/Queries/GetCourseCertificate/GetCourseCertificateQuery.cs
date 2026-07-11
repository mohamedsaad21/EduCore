using EduCore.Application.Bases;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace EduCore.Core.Features.Certificate.Queries.GetCourseCertificate;

public sealed record GetCourseCertificateQuery(Guid CourseId) : IRequest<Result<FileContentResult>>;