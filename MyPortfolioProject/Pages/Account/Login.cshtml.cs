using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;

namespace MyPortfolioProject.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Credential Credential { get; set; } = new Credential();
        public string Message { get; set; } = "";
        private readonly IConfiguration _configuration;
        public LoginModel(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync(string returnUrl = "")
        {
            if (!ModelState.IsValid)
                return Page();

            // Verify credential
            if (Credential.Passphrase == _configuration["Passphrase"])
            {
                // Creating security context
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, "AuthorizedUser")
                };

                var identity = new ClaimsIdentity(claims, "AuthCookie");
                ClaimsPrincipal claimsPrincipal = new(identity);

                await HttpContext.SignInAsync("AuthCookie", claimsPrincipal);

                if (!String.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);
                else
                    return RedirectToPage("/Index");
            }

            Message = "Invalid passphrase";
            return Page();
        }
    }

    public class Credential
    {
        [Required]
        [DataType(DataType.Password)]
        public string Passphrase { get; set; } = string.Empty;
    }
}
