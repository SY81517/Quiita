using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebApiValidation.Models
{
    public class CustomerValidateObject: IValidatableObject
    {
        private const string ErrorPrefix = "Invalid";
        public int? Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id == null)
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(Id)}");
            }
            if (1 > Id || Id  > 100)
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(Id)}");
            }
            if (string.IsNullOrEmpty(Surname))
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(Surname)}");
            }
            if (string.IsNullOrEmpty(Forename))
            {
                yield return new ValidationResult($"{ErrorPrefix} {nameof(Forename)}");
            }
        }
    }
}