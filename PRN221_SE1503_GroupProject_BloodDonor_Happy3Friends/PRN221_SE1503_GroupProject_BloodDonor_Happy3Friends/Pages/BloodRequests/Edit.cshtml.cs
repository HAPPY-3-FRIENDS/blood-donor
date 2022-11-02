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

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.BloodRequests
{
    public class EditModel : PageModel
    {
        private readonly BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;
        private readonly IBloodRequestRepository _bloodRequestRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public EditModel(BusinessObjects.Models.PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context, IBloodRequestRepository bloodRequestRepository, IOrganizationRepository organizationRepository)
        {
            _context = context;
            _bloodRequestRepository = bloodRequestRepository;
            _organizationRepository = organizationRepository;
        }

        [BindProperty]
        public BloodRequest BloodRequest { get; set; }

        public IActionResult OnGet(int id)
        {
            BloodRequest = _bloodRequestRepository.GetBloodRequestById(id);

            if (BloodRequest == null)
            {
                return NotFound();
            }

           ViewData["OrganizationId"] = new SelectList(_organizationRepository.GetOrganizations(), "Id", "Name");
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
                _bloodRequestRepository.UpdateBloodRequest(BloodRequest);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BloodRequestExists(BloodRequest.Id))
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

        private bool BloodRequestExists(int id)
        {
            return _bloodRequestRepository.GetBloodRequestById(id) != null;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
