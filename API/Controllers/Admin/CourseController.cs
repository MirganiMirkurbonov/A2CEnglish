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
[ApiExplorerSettings(GroupName = "admin")]
[Route("api/[controller]/[action]")]
public class CourseController(ICourseAdminService courseAdminService) : MainControllerBase<CourseController>
{
    [HttpPost]
    public async Task<DefaultResponse<CourseSingleViewModel>> Add(AddCourseRequest request)
        => await courseAdminService.AddAsync(request, CurrentUserId);

    [HttpGet]
    public async Task<DefaultResponse<ListResponse<CourseListViewModel>>> All()
        => await courseAdminService.GetAllAsync();

    [HttpPost]
    public async Task<DefaultResponse<CourseSingleViewModel>> UploadPhoto([FromForm] UploadCoursePhotoRequest request)
        => await courseAdminService.UploadPhotoAsync(request, CurrentUserId);

    [HttpPut]
    public async Task<DefaultResponse<CourseSingleViewModel>> Update(UpdateCourseRequest request)
        => await courseAdminService.UpdateAsync(request, CurrentUserId);

    [HttpDelete]
    public async Task<DefaultResponse<CourseSingleViewModel>> ToggleVisibility(Guid courseId)
        => await courseAdminService.ToggleVisibilityAsync(courseId, CurrentUserId);

    [HttpPost]
    public async Task<DefaultResponse<ListResponse<CourseListViewModel>>> Filter(FilterCourseRequest request)
        => await courseAdminService.FilterAsync(request, CurrentUserId);

}