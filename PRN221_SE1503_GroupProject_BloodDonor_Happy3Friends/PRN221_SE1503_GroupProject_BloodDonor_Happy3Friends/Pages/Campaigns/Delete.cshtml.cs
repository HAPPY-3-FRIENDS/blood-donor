using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class DeleteModel : PageModel
    {
        private readonly ICampaignRepository _campaignRepository;

        public DeleteModel(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        [BindProperty]
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

        public IActionResult OnPost(int id)
        {
            _campaignRepository.DeleteCampaignById(id);

            return RedirectToPage("./Index");
        }
    }
}