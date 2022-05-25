using RegistrationApi.Adapters;
using RegistrationApi.Models;

namespace RegistrationApi.Domain;

public class ReservationProcessor : IProcessReservations
{
    private readonly ScheduleApiAdapter _apiAdapter;
    private readonly RegistrationsAdapter _mongoAdapter;

    public ReservationProcessor(ScheduleApiAdapter apiAdapter, RegistrationsAdapter mongoAdapter)
    {
        _apiAdapter = apiAdapter;
        _mongoAdapter = mongoAdapter;
    }

    public async Task<RegistrationRequestResponse> ProcessReservationAsync(RegistrationRequest request)
    {
        // Check the schedule API to make sure that course is on that date.
        var response = await _apiAdapter.GetScheduleForCourseAsync(request.Course);

        var reservationToSave = new Reservation
        {
            Request = new RegistrationInfo { Course = request.Course, DateOfCourse = request.DateOfCourse!.Value, Name = request.Name }
        };
        if(response == null)
        {   
            reservationToSave.Status = RegistrationStatus.Denied;
            await _mongoAdapter.GetDocumentCollection().InsertOneAsync(reservationToSave);
            var fakeResult = new RegistrationRequestResponse(reservationToSave.Id.ToString(), RegistrationStatus.Denied, request);
            return fakeResult;
        } else
        {
            // we will assume that course is there here, but you should look for the date.
            reservationToSave.Status = RegistrationStatus.Pending;
            await _mongoAdapter.GetDocumentCollection().InsertOneAsync(reservationToSave);

            return new RegistrationRequestResponse(reservationToSave.Id.ToString(), RegistrationStatus.Pending, request);
        }
        
    }
}
