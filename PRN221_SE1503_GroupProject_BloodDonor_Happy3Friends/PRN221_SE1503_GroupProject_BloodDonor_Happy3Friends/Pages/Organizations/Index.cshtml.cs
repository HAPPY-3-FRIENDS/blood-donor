using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;
using System;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Organizations
{
    public class IndexModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;

        public IndexModel(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IList<Organization> Organizations { get;set; }

        public void OnGet()
        {
            Organizations = _organizationRepository.GetOrganizations();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }

        public IActionResult OnPostDelete(int itemId)
        {
            try
            {
                _organizationRepository.DeleteOrganizationById(itemId);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }
            return RedirectToPage("./Index");
        }

        /*public async Task OnGetAsync()
        {
            Organization = await _context.Organizations.ToListAsync();
        }*/
    }
}