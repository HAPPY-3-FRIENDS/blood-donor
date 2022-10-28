using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class DetailsModel : PageModel
    {
        private readonly ICampaignRepository _campaignRepository;

        public DetailsModel(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public Campaign Campaign { get; set; }

        public IActionResult OnGet(int id)
        {
            Campaign = _campaignRepository.GetCampaignById(id);

            if (Campaign == null)
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