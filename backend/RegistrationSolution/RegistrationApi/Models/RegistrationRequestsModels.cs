using System.ComponentModel.DataAnnotations;

namespace RegistrationApi.Models;

// {name: 'Jeff', dateOfCourse: 'THIS IS OUR JOB', course: '62797b1a1823357feb3756ac'}


//public record RegistrationRequest(
//    [Required]
//    string name, DateTime dateOfCourse, string course);

public record RegistrationRequest
{
    [Required]
    [MaxLength(100)]
    public string Name { get; init; } = string.Empty;

    [Required]
    public DateTime? DateOfCourse { get; init; }

    [Required]
    public string Course { get; init; } = string.Empty;
}


public record RegistrationRequestResponse(string registrationId, RegistrationStatus status, RegistrationRequest request );

public enum RegistrationStatus { Approved, Pending, Denied};
