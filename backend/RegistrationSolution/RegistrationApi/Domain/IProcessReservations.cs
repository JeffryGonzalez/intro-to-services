using RegistrationApi.Models;

namespace RegistrationApi.Domain;

public interface IProcessReservations
{
    Task<RegistrationRequestResponse> ProcessReservationAsync(RegistrationRequest request);
}
