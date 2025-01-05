using Database.Tables;
using Domain.Extensions;
using Domain.Models.API.Course;
using Mapster;

namespace Application.Mappers.Result;

public class CourseListViewModelMapper : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config
            .NewConfig<Course, CourseListViewModel>()
            .ConstructUsing(src => Map(src));
    }

    private static CourseListViewModel Map(Course src)
    {
        return new CourseListViewModel(
            Id: src.Id,
            Title: src.Title,
            Description: src.Description,
            EnglishLevel: src.EnglishLevel,
            PhotoPath: src.PhotoPath.GetServerPath(),
            CreatedDate: src.CreatedDate,
            IsVisible: src.IsVisible);
    }
}