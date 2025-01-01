using Database;
using Domain.Models.API.Course;
using Domain.Models.Response;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminLogics.Course;

internal class CourseAdminService(EntityContext context) : ICourseAdminService
{
    public async Task<DefaultResponse<ListResponse<CourseListViewModel>>> GetAllCourses()
    {
        var courses = await context.Courses.Select(x => x.Adapt<CourseListViewModel>()).ToListAsync();
        return new ListResponse<CourseListViewModel>(courses);
    }

    public async Task<DefaultResponse<CourseSingleViewModel>> AddCourse(AddCourseRequest request, Guid currentUserId)
    {
        var newCourse = (request, currentUserId).Adapt<Database.Tables.Course>();
        
        await context.Courses.AddAsync(newCourse);
        await context.SaveChangesAsync();
        
        return newCourse.Adapt<CourseSingleViewModel>();
    }

    public async Task<DefaultResponse<CourseSingleViewModel>> UploadCoursePhoto(UploadCoursePhotoRequest request, Guid currentUserId)
    {
        throw new NotImplementedException();
    }
}