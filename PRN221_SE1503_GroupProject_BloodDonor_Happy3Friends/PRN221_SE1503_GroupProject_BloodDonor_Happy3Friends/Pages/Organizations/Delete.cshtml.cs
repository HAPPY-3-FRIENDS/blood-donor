using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Organizations
{
    public class DeleteModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;

        public DeleteModel(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        [BindProperty]
        public Organization Organization { get; set; }

        public IActionResult OnGet(int id)
        {
            Organization = _organizationRepository.GetOrganizationById(id);

            if (Organization == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPost(int id)
        {
            Organization = _organizationRepository.GetOrganizationById(id);

            if (Organization != null)
            {
                _organizationRepository.DeleteOrganization(Organization);
            }

            return RedirectToPage("./Index");
        }
    }
}
