using AutoMapper;
using Domain.DTOs.CoursesDTOs;
using Domain.Entities;

namespace Infrastructure.AutoMapper;

public class InfrastructureProfile : Profile
{
    public InfrastructureProfile()
    {
        CreateMap<Courses, GetCourseDto>();
        CreateMap<CreateCourseDto, Courses>();
        CreateMap<UpdateCourseDto, Courses>();
    }
}
