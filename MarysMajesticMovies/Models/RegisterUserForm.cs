using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MarysMajesticMovies
{
    public class RegisterUserForm
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm Password")]
        [Compare("Password", ErrorMessage = "The confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß-]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß-]+$", ErrorMessage = "Use letters only please")]
        [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Address")]
        [StringLength(50, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 2)]
        [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß0-9 ,./-]+$", ErrorMessage = "Only numbers, letters, space and ,./- are allowed")]
        public string Address { get; set; }

        [Required]
        [Range(9999, 99999, ErrorMessage = "The zipcode must be 5 numbers long")]
        [Display(Name = "Zip Code")]
        public int ZipCode { get; set; }

        [Required]
        [Display(Name = "City")]
        [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß-]+$", ErrorMessage = "Use letters only please")]
        [StringLength(86, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
        public string City { get; set; }

        [Required]
        [Display(Name = "Telephone")]
        [Range(10000000, 99999999999, ErrorMessage = "The {0} has to be 9-13 digits long. It has to start with 1-2 zeros.")]
        [StringLength(13, ErrorMessage = "The {0} has to be 9-13 digits long. It has to start with 1-2 zeros.", MinimumLength = 9)]
        public string PhoneNumber { get; set; }
    }
}
