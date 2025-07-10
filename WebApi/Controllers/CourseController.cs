using System.Globalization;
using Domain.ApiResponses;
using Domain.DTOs.CoursesDTOs;
using Domain.Filters;
using Infrastructure.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;



[ApiController]
[Route("api/course")]
public class CourseController(ICourseService service)
{
    [HttpGet]
    public async Task<PagedResponse<List<GetCourseDto>>> GetCourses(CourseFilter filter)
    {
        return await service.GetCourses(filter);
    }

    [HttpPost]
    public async Task<Response<string>> CreateCourse(CreateCourseDto courseDto)
    {
        return await service.CreateCourse(courseDto);
    }

    [HttpPut]
    public async Task<Response<string>> UpdateCourse(int id, UpdateCourseDto updateCourseDto)
    {
        return await service.UpdateCourse(id, updateCourseDto);
    }

    [HttpDelete]
    public async Task<Response<string>> DeleteCourse(int id)
    {
        return await service.DeleteCourse(id);
    }
}