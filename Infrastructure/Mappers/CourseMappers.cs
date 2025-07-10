using Domain.DTOs.CoursesDTOs;
using Domain.Entities;

namespace Infrastructure.Mappers;

public static class CourseMappers
{
    public static Courses ToEntity(CreateCourseDto courseDto)
    {
        return new Courses
        {
            Title = courseDto.Title,
            Description = courseDto.Description,
            Price = courseDto.Price,
        };
    }

    public static void ToEntity(this Courses course, UpdateCourseDto courseDto)
    {
        course.Title = courseDto.Title;
        course.Description = courseDto.Description;
        course.Price = courseDto.Price;
    }
}
