using Database;
using Domain.Enums;
using Domain.Models.API.Course;
using Domain.Models.Response;
using Infrastructure.Interfaces;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.AdminLogics.Course;

internal class CourseAdminService(EntityContext context, IFileHandler fileHandler) : ICourseAdminService
{
    public async Task<DefaultResponse<ListResponse<CourseListViewModel>>> GetAllAsync()
    {
        var courses = await context.Courses.Select(x => x.Adapt<CourseListViewModel>()).ToListAsync();
        return new ListResponse<CourseListViewModel>(courses);
    }

    public async Task<DefaultResponse<CourseSingleViewModel>> AddAsync(AddCourseRequest request, Guid currentUserId)
    {
        var newCourse = (request, currentUserId).Adapt<Database.Tables.Course>();
        
        await context.Courses.AddAsync(newCourse);
        await context.SaveChangesAsync();
        
        return newCourse.Adapt<CourseSingleViewModel>();
    }

    public async Task<DefaultResponse<CourseSingleViewModel>> UploadPhotoAsync(UploadCoursePhotoRequest request, Guid currentUserId)
    {
        var course = await context.Courses
            .Include(x=>x.Lessons)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if(course == null)
            return new ErrorModel(ErrorEnum.CourseNotFound);

        var photo = await fileHandler.UploadFileAsync(request.Photo, "CoursePhotos");
        if(photo == null)
            return new ErrorModel(ErrorEnum.PhotoUploadingFailed);

        course.PhotoPath = photo.Path;
        await context.SaveChangesAsync();
        return course.Adapt<CourseSingleViewModel>();
    }

    public async Task<DefaultResponse<CourseSingleViewModel>> UpdateAsync(UpdateCourseRequest request, Guid currentUserId)
    {
        var course = await context.Courses
            .Include(x=>x.Lessons)
            .FirstOrDefaultAsync(x => x.Id == request.Id);

        if(course == null)
            return new ErrorModel(ErrorEnum.CourseNotFound);

        course.Title = request.Title;
        course.Description = request.Description;
        course.EnglishLevel = request.EnglishLevel;
        course.UpdatedDate = DateTime.UtcNow;

        await context.SaveChangesAsync();
        return course.Adapt<CourseSingleViewModel>();
    }

    public async Task<DefaultResponse<CourseSingleViewModel>> ToggleVisibilityAsync(Guid courseId, Guid currentUserId)
    {
        var course = await context.Courses
            .Include(x => x.Lessons)
            .FirstOrDefaultAsync(x => x.Id == courseId);

        if (course == null)
            return new ErrorModel(ErrorEnum.CourseNotFound);

        course.IsVisible = !course.IsVisible;
        await context.SaveChangesAsync();
        return course.Adapt<CourseSingleViewModel>();
    }
}