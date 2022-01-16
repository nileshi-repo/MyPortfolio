using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace MyPortfolioProject.Pages
{
    [Authorize]
    public class EducationModel : PageModel
    {

        public void OnGet()
        {
        }
    }
}
