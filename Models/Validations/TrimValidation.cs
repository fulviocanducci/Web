using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace Models.Validations
{
   public sealed class TrimAttribute : ValidationAttribute, IClientModelValidator
   {
      protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
      {
         if (value == null || string.IsNullOrWhiteSpace(value.ToString()))
         {
            return new ValidationResult(GetErrorMessage());
         }
         return ValidationResult.Success;
      }

      public void AddValidation(ClientModelValidationContext context)
      {
         context.Attributes.Add("data-val-trim", GetErrorMessage());
      }

      internal string GetErrorMessage()
      {
         return ErrorMessage ?? "Space invalid";
      }
   }
}
