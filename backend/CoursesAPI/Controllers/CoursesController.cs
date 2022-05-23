using CoursesAPI.Adapters;
using Microsoft.AspNetCore.Mvc;

namespace CoursesAPI.Controllers;

[Route("courses")]
public class CoursesController : ControllerBase
{
    private readonly CourseRepository _repository;

    public CoursesController(CourseRepository repository)
    {
        _repository = repository;
    }

    [HttpGet("")]
    public async Task<ActionResult> GetAllCourses()
    {
        var data = await _repository.GetCoursesAsync();

        return Ok(new { data, when = DateTime.Now });
    }
}
