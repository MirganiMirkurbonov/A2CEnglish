using Microsoft.AspNetCore.Http;

namespace Domain.Models.API.Course;

public record UploadCoursePhotoRequest(Guid Id, IFormFile Photo);