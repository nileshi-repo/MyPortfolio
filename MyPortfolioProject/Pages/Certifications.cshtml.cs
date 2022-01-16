using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolioProject.Pages
{
    [Authorize]
    public class CertificationsModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
