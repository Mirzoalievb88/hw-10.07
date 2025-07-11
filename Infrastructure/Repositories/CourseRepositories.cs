using System.Collections.Immutable;
using System.Linq.Expressions;
using Domain.ApiResponses;
using Domain.DTOs.CoursesDTOs;
using Domain.Entities;
using Domain.Filters;
using Domain.Paginations;
using Infrastructure.Data;
using Infrastructure.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories;

public class CoursesRepository(DataContext context) : ICourseRepository
{
    public async Task<PagedResponse<List<Courses>>> GetAllAsync(CourseFilter filter)
    {
        var query = context.Courses.AsQueryable();

        if (!string.IsNullOrEmpty(filter.Title))
        {
            query = query.Where(c => c.Title!.ToLower().Trim().Contains(filter.Title.ToLower().Trim()));
        }

        if (filter.MinPrice != null)
        {
            query = query.Where(c => c.Price >= filter.MinPrice);
        }

        if (filter.MaxPrice != null)
        {
            query = query.Where(c => c.Price <= filter.MaxPrice);
        }


        var pagination = new Pagination<Courses>(query);
        return await pagination.GetPagedResponseAsync(filter.PageNumber, filter.PageSize);
    }

    

    public async Task<Courses?> GetAsync(int id)
    {
        var Courses = await context.Courses.FindAsync(id);
        return Courses;
    }

    public async Task<int> CreateAsync(Courses Courses)
    {
        await context.Courses.AddAsync(Courses);
        return await context.SaveChangesAsync();
    }

    public async Task<int> UpdateAsync(Courses Courses)
    {
        context.Courses.Update(Courses);
        return await context.SaveChangesAsync();
    }

    public async Task<int> DeleteAsync(Courses Courses)
    {
        context.Courses.Remove(Courses);
        return await context.SaveChangesAsync();
    }

    public async Task<List<Courses>> GetAllAsync(Expression<Func<Courses, bool>>? filter = null)
    {
        var query = context.Courses.AsQueryable();

        if (filter != null)
        {
            query = query.Where(filter);
        }

        return await query.ToListAsync();
    }
}
