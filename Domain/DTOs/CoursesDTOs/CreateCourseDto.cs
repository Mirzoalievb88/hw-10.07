namespace Domain.DTOs.CoursesDTOs;

public class CreateCourseDto
{
    public string? Title { get; set; }
    public string? Description { get; set; }
    public decimal Price { get; set; }
}