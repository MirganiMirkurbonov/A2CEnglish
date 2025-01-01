using Domain.Models.API.Course;
using Domain.Models.Response;

namespace Application.Logics.Course;

public interface ICourse
{
    Task<DefaultResponse<ListResponse<CourseListViewModel>>> GetAllCourses(); 
}