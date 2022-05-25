using RegistrationApi.Adapters;
using RegistrationApi.Models;

namespace RegistrationApi.Domain;

public class ReservationProcessor : IProcessReservations
{
    private readonly ScheduleApiAdapter _apiAdapter;

    public ReservationProcessor(ScheduleApiAdapter apiAdapter)
    {
        _apiAdapter = apiAdapter;
    }

    public async Task<RegistrationRequestResponse> ProcessReservationAsync(RegistrationRequest request)
    {
        // Check the schedule API to make sure that course is on that date.
        var response = await _apiAdapter.GetScheduleForCourseAsync(request.Course);
        if(response == null)
        {
            var fakeResult = new RegistrationRequestResponse("42", RegistrationStatus.Denied, request);
            return fakeResult;
        } else
        {
            // we will assume that course is there here, but you should look for the date.
            return new RegistrationRequestResponse("42", RegistrationStatus.Pending, request);
        }
        
    }
}
