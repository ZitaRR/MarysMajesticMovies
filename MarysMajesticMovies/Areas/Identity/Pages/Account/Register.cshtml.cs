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
        public RegisterUserForm Input { get; set; }

        public string ReturnUrl { get; set; }

        public async Task<IActionResult> OnPostAsync(string returnUrl = null)
        {
            returnUrl ??= Url.Content("~/");
            isEmailValid = true;

            if (ModelState.IsValid)
            {
                isEmailValid = await ValidateEmail(Input.Email);

                if (isEmailValid)
                {
                    var user = new User { 
                        UserName = Input.Email.Trim(),
                        Email = Input.Email.Trim(), 
                        EmailConfirmed = true, 
                        FirstName = Input.FirstName.Trim(), 
                        LastName = Input.LastName.Trim(), 
                        Address = Input.Address.Trim(), 
                        ZipCode = Input.ZipCode, 
                        City = Input.City.Trim(),
                        PhoneNumber = Input.PhoneNumber.Trim()
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
            string APIKey = "GetByVerimail";
            string APIURL = $"https://api.verimail.io/v3/verify?email={mail}&key={APIKey}";

            try
            {
                HttpResponseMessage response = await client.GetAsync(APIURL);
            
                if (response.StatusCode == HttpStatusCode.OK)
                {
                    var responscontext = await response.Content.ReadAsStringAsync();

                    if (responscontext.Contains("result\": \"deliverable") || responscontext.Contains("result\": \"catch_all"))
                    {
                        Console.WriteLine(responscontext);
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
