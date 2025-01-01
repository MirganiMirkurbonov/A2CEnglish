using Database;
using Domain.Models.API.Course;
using Domain.Models.Response;

namespace Application.Logics.Course;

internal class CourseService(EntityContext entityContext) : ICourse
{
    public async Task<DefaultResponse<ListResponse<CourseListViewModel>>> GetAllCourses()
    {
        throw new NotImplementedException();
    }
}