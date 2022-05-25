using Microsoft.AspNetCore.Mvc;
using RegistrationApi.Domain;
using RegistrationApi.Models;

namespace RegistrationApi.Controller;

[ApiController]
public class RegistrationRequests : ControllerBase
{

    private readonly IProcessReservations _reservationProcessor;

    public RegistrationRequests(IProcessReservations reservationProcessor)
    {
        _reservationProcessor = reservationProcessor;
    }

    [HttpPost("registration-requests")]
    public async Task<ActionResult> AddRegistrationRequest([FromBody] RegistrationRequest request)
    {

        RegistrationRequestResponse response = await _reservationProcessor.ProcessReservationAsync(request);

        return StatusCode(201, response);
    }
}
