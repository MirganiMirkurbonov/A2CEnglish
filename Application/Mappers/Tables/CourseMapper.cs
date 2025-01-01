using Database.Tables;
using Domain.Models.API.Course;
using Mapster;

namespace Application.Mappers.Tables;

public class CourseMapper: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<(AddCourseRequest, Guid), Course>()
            .ConstructUsing(src => Map(src));
    }

    private static Course Map((AddCourseRequest, Guid) src)
    {
        return new Course
        {
            Title = src.Item1.Title,
            Description = src.Item1.Description,
            EnglishLevel = src.Item1.EnglishLevel,
            CreatedUserId = src.Item2
        };
    }
}