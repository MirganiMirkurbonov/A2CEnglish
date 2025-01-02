using API.Helpers;
using Application.AdminLogics.Course;
using Domain.Attributes;
using Domain.Models.API.Course;
using Domain.Models.Response;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Admin;

[ApiController]
[Authorize]
[AutoPermission]
[Route("api-admin/[controller]/[action]")]
[ApiExplorerSettings(GroupName = "admin")]
public class CourseController(ICourseAdminService courseAdminService) : MainControllerBase<CourseController>
{
    [HttpPost]
    public async Task<DefaultResponse<CourseSingleViewModel>> Add(AddCourseRequest request)
    {
        return await courseAdminService.AddAsync(request, CurrentUserId);
    }
    
    [HttpGet]
    public async Task<DefaultResponse<ListResponse<CourseListViewModel>>> All()
    {
        return await courseAdminService.GetAllAsync();
    }

    [HttpPost]
    public async Task<DefaultResponse<CourseSingleViewModel>> UploadPhoto([FromForm] UploadCoursePhotoRequest request)
    {
        return await courseAdminService.UploadPhotoAsync(request, CurrentUserId);
    }

    [HttpPut]
    public async Task<DefaultResponse<CourseSingleViewModel>> Update(UpdateCourseRequest request)
    {
        return await courseAdminService.UpdateAsync(request, CurrentUserId);
    }

    [HttpDelete]
    public async Task<DefaultResponse<CourseSingleViewModel>> ToggleVisibility(Guid courseId)
    {
        return await courseAdminService.ToggleVisibilityAsync(courseId, CurrentUserId);
    }
}