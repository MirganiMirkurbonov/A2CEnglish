using Domain.Models.API.Course;
using Domain.Models.Response;

namespace Application.AdminLogics.Course;

public interface ICourseAdminService
{ 
    Task<DefaultResponse<ListResponse<CourseListViewModel>>> GetAllCourses();
    Task<DefaultResponse<CourseSingleViewModel>> AddCourse(AddCourseRequest request, Guid currentUserId);
    Task<DefaultResponse<CourseSingleViewModel>> UploadCoursePhoto(UploadCoursePhotoRequest request, Guid currentUserId);
}