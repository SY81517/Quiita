using System.ComponentModel.DataAnnotations;

namespace WebApiValidation.Models
{
    public class RequiredCustomAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            if (value == null)
                return false;
            return !(value is string str) ||  str.Trim().Length != 0;
        }
    }
}