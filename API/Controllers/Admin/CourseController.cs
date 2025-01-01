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
[Route("api-admin/v1/[controller]/[action]")]
[ApiExplorerSettings(GroupName = "admin")]
public class CourseController(ICourseAdminService courseAdminService) : MainControllerBase<CourseController>
{
    [HttpPost]
    public async Task<DefaultResponse<CourseSingleViewModel>> AddCourse(AddCourseRequest request)
    {
        return await courseAdminService.AddCourse(request, CurrentUserId);
    }
}