using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Organizations
{
    public class EditModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;

        public EditModel(IOrganizationRepository organizationRepository)
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _organizationRepository.UpdateOrganization(Organization);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!OrganizationExists(Organization.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool OrganizationExists(int id)
        {
            return _organizationRepository.GetOrganizationById(id) != null;
        }
    }
}
