using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.BloodRequests
{
    public class DetailsModel : PageModel
    {
        private readonly IBloodRequestRepository _bloodRequestRepository;

        public DetailsModel(IBloodRequestRepository bloodRequestRepository)
        {
            _bloodRequestRepository = bloodRequestRepository;
        }

        public BloodRequest BloodRequest { get; set; }

        public IActionResult OnGet(int id)
        {
            BloodRequest = _bloodRequestRepository.GetBloodRequestById(id);

            if (BloodRequest == null)
            {
                return NotFound();
            }
            return Page();
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
