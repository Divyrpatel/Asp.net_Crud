using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;

namespace Project.Models
{
    public class Person
    {
        [Key]
        public int Person_Id { get; set; }

        [Required(ErrorMessage = "Enter a Name")]
        [Display(Name = "Employee Name")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "Enter a Email")]
        [Display(Name = "Email Id")]
        [DataType(DataType.EmailAddress)]
        public string? Email { get; set; }

        [Required(ErrorMessage = "Enter a MobileNo")]

        [RegularExpression(@"^(\d{10})$", ErrorMessage = "Enter a Valid Mobile Number ")]
        public string? MobileNo { get; set; }

        [Required(ErrorMessage = "Enter a Address")]
        public string? Address { get; set; }

        public int? State_Id { get; set; }
        
        [ForeignKey("State_Id")]
        [ValidateNever]
        public State? State { get; set; }
        [NotMapped]
        public String? StateName { get; set; }

        public int City_Id { get; set; }

        [ForeignKey("City_Id")]
        [ValidateNever]
        public City? City { get; set; }

        [NotMapped]
        public String? CityName { get; set; }
    }
}
