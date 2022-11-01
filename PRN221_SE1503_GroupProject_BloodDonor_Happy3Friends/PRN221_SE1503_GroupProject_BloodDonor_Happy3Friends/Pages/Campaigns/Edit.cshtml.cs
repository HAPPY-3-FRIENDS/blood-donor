using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;
using System;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class EditModel : PageModel
    {
        private readonly ICampaignRepository _campaignRepository;

        public EditModel(ICampaignRepository campaignRepository)
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

        public IActionResult OnPost()
        {
            if (DateTime.Compare(Campaign.StartDate, Campaign.EndDate) > 0)
            {
                ModelState.AddModelError("Campaign.StartDate", "Ngày bắt đầu không được đến sau ngày kết thúc!");
                ModelState.AddModelError("Campaign.EndDate", "Ngày kết thúc không được đến trước ngày bắt đầu!");
            }

            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _campaignRepository.UpdateCampaign(Campaign);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CampaignExists(Campaign.Id))
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

        private bool CampaignExists(int id)
        {
            return (_campaignRepository.GetCampaignById(id) != null); 
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}