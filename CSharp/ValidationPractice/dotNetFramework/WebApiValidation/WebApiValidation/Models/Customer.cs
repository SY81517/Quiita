using System.ComponentModel.DataAnnotations;

namespace WebApiValidation.Models
{
    public class Customer
    {
        [Required(ErrorMessage = "Require ID")]
        [Range(1,100)]
        public int? Id { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public string Forename { get; set; }
    }
}