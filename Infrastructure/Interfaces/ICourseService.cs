using System.Linq.Expressions;
using Domain.ApiResponses;
using Domain.DTOs.CoursesDTOs;
using Domain.Entities;
using Domain.Filters;
using Microsoft.EntityFrameworkCore.Diagnostics;

namespace Infrastructure.Interfaces;

public interface ICourseService
{
    Task<PagedResponse<List<GetCourseDto>>> GetCourses(CourseFilter filter);
    Task<Response<List<GetCourseDto>>> GetCourses();
    Task<Response<GetCourseDto?>> GetCourse(int id);
    Task<Response<string>> CreateCourse(CreateCourseDto createCourseDto);
    Task<Response<string>> UpdateCourse(int id, UpdateCourseDto updateCourseDto);
    Task<Response<string>> DeleteCourse(int id);
}
