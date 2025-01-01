using Database.Tables;
using Domain.Models.API.Course;
using Mapster;

namespace Application.Mappers.Result;

public class CourseSingleViewModelMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<Course, CourseSingleViewModel>()
            .ConstructUsing(src => Map(src));

    }

    private static CourseSingleViewModel Map(Course src)
    {
        return new CourseSingleViewModel();
    }
}