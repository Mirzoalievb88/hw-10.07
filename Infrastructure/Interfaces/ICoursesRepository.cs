using Domain.ApiResponses;
using Domain.Entities;
using Domain.Filters;

namespace Infrastructure.Interfaces;

public interface ICourseRepository
{
    
    Task<PagedResponse<List<Courses>>> GetAllAsync(CourseFilter filter);
    Task<Courses?> GetAsync(int id);
    Task<int> CreateAsync(Courses course);
    Task<int> UpdateAsync(Courses course);
    Task<int> DeleteAsync(Courses course);
}
