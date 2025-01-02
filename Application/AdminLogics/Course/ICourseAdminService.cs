using Domain.Models.API.Course;
using Domain.Models.Response;

namespace Application.AdminLogics.Course;

public interface ICourseAdminService
{ 
    Task<DefaultResponse<ListResponse<CourseListViewModel>>> GetAllAsync();
    Task<DefaultResponse<CourseSingleViewModel>> AddAsync(AddCourseRequest request, Guid currentUserId);
    Task<DefaultResponse<CourseSingleViewModel>> UploadPhotoAsync(UploadCoursePhotoRequest request, Guid currentUserId);
    Task<DefaultResponse<CourseSingleViewModel>> UpdateAsync(UpdateCourseRequest request, Guid currentUserId);
    Task<DefaultResponse<CourseSingleViewModel>> ToggleVisibilityAsync(Guid courseId, Guid currentUserId);
}