namespace RegistrationApi.Adapters;

public class ScheduleApiAdapter
{
    private readonly HttpClient _httpClient;
    private IConfiguration _config;

    public ScheduleApiAdapter(HttpClient httpClient, IConfiguration config)
    {
        _httpClient = httpClient;
        _config = config;
    }

    public async Task<CourseScheduleResponse>? GetScheduleForCourseAsync(string courseId)
    {
        var path = _config.GetValue < string > ("schedulePath");
        var response = await _httpClient.GetAsync($"{path}/schedule/{courseId}");
        if(response.StatusCode == System.Net.HttpStatusCode.NotFound)
        {
            return null;
        } else
        {
            response.EnsureSuccessStatusCode(); // if the status is 200-299 throws an exception
            var schedule = await response.Content.ReadFromJsonAsync<CourseScheduleResponse>();

            return schedule!;
        }
    }
}


public class CourseScheduleResponse
{
    public List<CourseOccurrance> data { get; set; } = new List<CourseOccurrance>();
    public string courseId { get; set; } = string.Empty;
}

public class CourseOccurrance
{
    public DateTime startDate { get; set; }
    public DateTime endDate { get; set; }
}
