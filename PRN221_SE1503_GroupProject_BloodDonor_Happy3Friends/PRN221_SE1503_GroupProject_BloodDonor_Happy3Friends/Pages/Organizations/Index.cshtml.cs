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
    public class IndexModel : PageModel
    {
        private readonly IOrganizationRepository _organizationRepository;

        public IndexModel(IOrganizationRepository organizationRepository)
        {
            _organizationRepository = organizationRepository;
        }

        public IList<Organization> Organization { get;set; }

        public void OnGet()
        {
            Organization = _organizationRepository.GetOrganizations();
        }

        /*public async Task OnGetAsync()
        {
            Organization = await _context.Organizations.ToListAsync();
        }*/
    }
}
