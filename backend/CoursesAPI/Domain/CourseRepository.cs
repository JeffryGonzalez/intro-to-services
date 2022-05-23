using CoursesAPI.Adapters;
using MongoDB.Driver;

namespace CoursesAPI.Domain;

public class CourseRepository
{
    private readonly CoursesMongoDbAdapter _adapter;

    public CourseRepository(CoursesMongoDbAdapter adapter)
    {
        _adapter = adapter;
    }

    public async Task<List<CourseListItemModel>> GetCoursesAsync()
    {
        var projection = Builders<Course>.Projection.Expression(course => new CourseListItemModel(course.Id.ToString(), course.Title, course.Blurb, course.Category));

        var sort = Builders<Course>.Sort.Ascending(c => c.Category).Ascending(c => c.PositionInCategory);

        var courses = await _adapter.GetCoursesCollection()
            
            .Find((_) => true)
            .Sort(sort)
         
            
            .Project(projection).ToListAsync();

        return courses;

    }
}
