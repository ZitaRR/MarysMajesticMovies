using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace MarysMajesticMovies.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<User> _signInManager;
        private readonly UserManager<User> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        static HttpClient client = new HttpClient();
        public bool isEmailValid = true;
        public string invalidEmailMessage;

        public RegisterModel(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            ILogger<RegisterModel> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
        }

        [BindProperty]
        public InputModel Input { get; set; }

        public string ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
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
            [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß]+$", ErrorMessage = "Use letters only please")]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            public string FirstName { get; set; }

            [Required]
            [Display(Name = "Last Name")]
            [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß]+$", ErrorMessage = "Use letters only please")]
            [StringLength(20, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            public string LastName { get; set; }

            [Required]
            [Display(Name = "Address")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß0-9 ,./-]+$", ErrorMessage = "Only numbers, letters, space and ,./- are allowed")]
            public string Address { get; set; }

            [Required]
            [Range(9999, 99999, ErrorMessage = "The zipcode must be 5 numbers long")]
            [Display(Name = "Zip Code")]
            public int ZipCode { get; set; }

            [Required]
            [Display(Name = "City")]
            [RegularExpression(@"^[a-zA-ZåäöüÅÄÖÜß]+$", ErrorMessage = "Use letters only please")]
            [StringLength(86, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 1)]
            public string City { get; set; }

            [Required]
            [Display(Name = "Telephone")]
            [Range(10000000, 99999999999, ErrorMessage = "The {0} must only contain numbers and be 9-13 digits long")]
            [StringLength(13, ErrorMessage = "The {0} must only contain numbers and be 9-13 digits long", MinimumLength = 9)]
            public string PhoneNumber { get; set; }
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Content("~/");
            isEmailValid = true;

            if (ModelState.IsValid)
            {
                isEmailValid = await ValidateEmail(Input.Email);

                if (isEmailValid)
                {
                    var user = new User { 
                        UserName = Input.Email, 
                        Email = Input.Email, 
                        EmailConfirmed = true, 
                        FirstName = Input.FirstName, 
                        LastName = Input.LastName, 
                        Address = Input.Address, 
                        ZipCode = Input.ZipCode, 
                        City = Input.City,
                        PhoneNumber = Input.PhoneNumber
                    };

                    var result = await _userManager.CreateAsync(user, Input.Password);
                    if (result.Succeeded)
                    {
                        _logger.LogInformation("User created a new account with password.");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return Page();
        }

        public async Task<bool> ValidateEmail(string mail)
        {
            string APIKey = "BAED4157487D4C4C9060250537E2B173";
            string APIURL = $"https://api.verimail.io/v3/verify?email={mail}&key={APIKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(APIURL);
            
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var myObject = await response.Content.ReadAsStringAsync();

                    if (myObject.Contains("result\": \"deliverable"))
                    {
                        Console.WriteLine(myObject);
                        return true;
                    }
                    invalidEmailMessage = "Email is not valid, please try another one!";
                    return false;
                }
                else if (response.StatusCode == HttpStatusCode.PaymentRequired)
                {
                    invalidEmailMessage = "No more user accounts, try next month!";
                    return false;
                }
            }
            catch (Exception)
            {
            }

            invalidEmailMessage = "Server error, please try again!";
            return false;
        }
    }
}
