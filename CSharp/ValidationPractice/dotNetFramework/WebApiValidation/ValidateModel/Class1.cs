using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ValidateModel
{
    public class Customer : IValidatableObject
    {
        private const string _errorPrefix = "Invalid";
        public int Id { get; set; }
        public string Surname { get; set; }
        public string Forename { get; set; }
        
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Id < 0)
            {
                yield return new ValidationResult($"{_errorPrefix} {nameof(Id)}");
            }
            if (string.IsNullOrEmpty(Surname))
            {
                yield return new ValidationResult($"{_errorPrefix} {nameof(Surname)}");
            }
            if (string.IsNullOrEmpty(Forename))
            {
                yield return new ValidationResult($"{_errorPrefix} {nameof(Forename)}");
            }
        }
    }
}
