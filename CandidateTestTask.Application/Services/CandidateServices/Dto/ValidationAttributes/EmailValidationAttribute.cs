using System.ComponentModel.DataAnnotations;

namespace CandidateTestTask.Application.Services.CandidateServices;

public class EmailValidationAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        var dto = validationContext.ObjectInstance as CandidateCreateDto;

        if (dto == null ||
            string.IsNullOrWhiteSpace(dto.Email) ||
            !dto.IsValidEmail(dto.Email)
        )
        {
            return new ValidationResult("Invalid Email");
        }

        return ValidationResult.Success;
    }
}
