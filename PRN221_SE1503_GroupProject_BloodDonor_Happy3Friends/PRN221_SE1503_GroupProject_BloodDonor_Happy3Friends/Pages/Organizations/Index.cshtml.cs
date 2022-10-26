﻿using System;
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
    public class IndexModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;

        [BindProperty]
        public Organization Organization { get; set; }

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

        public IActionResult OnPostDelete(int id)
        {
            Organization = _organizationRepository.GetOrganizationById(id);

            if (Organization != null)
            {
                _organizationRepository.DeleteOrganization(Organization);
            }

            return RedirectToPage("./Index");
        }

        /*public async Task OnGetAsync()
        {
            Organization = await _context.Organizations.ToListAsync();
        }*/
    }
}
