using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.RegularExpressions;

public class FirstLetterCapitalizedCZAttribute
    : ValidationAttribute, IClientModelValidator
{
    protected override ValidationResult? IsValid(
        object? value,
        ValidationContext validationContext)
    {
        if (value is not string text || string.IsNullOrWhiteSpace(text))
            return ValidationResult.Success;

        text = text.Trim();

        // Česká velká písmena + A-Z
        Regex regex = new Regex(@"^[A-ZÁČĎÉĚÍŇÓŘŠŤÚŮÝŽ]");

        if (!regex.IsMatch(text))
        {
            return new ValidationResult(
                ErrorMessage ?? "Text musí začínat velkým písmenem."
            );
        }

        return ValidationResult.Success;
    }

    public void AddValidation(ClientModelValidationContext context)
    {
        context.Attributes.Add("data-val", "true");
        context.Attributes.Add(
            "data-val-firstlettercapitalizedcz",
            ErrorMessage ??
            "Text musí začínat velkým písmenem."
        );
    }
}
