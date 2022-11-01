using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;
using System;

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
            try
            {
                _campaignRepository.DeleteCampaignById(id);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
            }

            return RedirectToPage("./Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}