using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Organizations
{
    public class CreateModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;

        public CreateModel(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Organization Organization { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _organizationRepository.CreateOrganization(Organization);

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}