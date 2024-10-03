using System.Text.RegularExpressions;

namespace CandidateTestTask.Application.Services.CandidateServices;

public class CandidateCreateDto
{
    public  string FirstName { get; set; }
    public  string LastName { get; set; }
    public string? PhoneNumber { get; set; }
    [EmailValidation]
    public string Email { get; set; }
    public string? LinkedInUrl { get; set; }
    public string? GitHubUrl { get; set; }
    public string? Comment { get; set; }
    public bool IsValidEmail(string email)
    {
        var regex = new Regex("^[\\w\\d]{5,20}@[\\w\\d]+.[\\w]{2,}$");
        return regex.IsMatch(email);
    }
}
public class CandidateUpdateDto : CandidateCreateDto
{
    public int Id { get; set; }
}
