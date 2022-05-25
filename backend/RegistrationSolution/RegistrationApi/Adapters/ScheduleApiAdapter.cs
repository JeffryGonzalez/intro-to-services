namespace RegistrationApi.Adapters;

public class ScheduleApiAdapter
{
    private readonly HttpClient _httpClient;

    public ScheduleApiAdapter(HttpClient httpClient)
    {
        _httpClient = httpClient;

    }

    public async Task<CourseScheduleResponse>? GetScheduleForCourseAsync(string courseId)
    {
        var response = await _httpClient.GetAsync($"/schedule/{courseId}");
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
