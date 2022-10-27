using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;
using Microsoft.AspNetCore.Http;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class IndexModel : PageModel
    {
        private readonly ICampaignRepository _campaignRepository;

        public IndexModel(ICampaignRepository campaignRepository)
        {
            _campaignRepository = campaignRepository;
        }

        public IList<Campaign> Campaigns { get;set; }

        public void OnGet()
        {
            string organizationId = HttpContext.Session.GetString("phone");
            if (organizationId != null)
            {
                Campaigns = _campaignRepository.GetCampaignsByOrganizationId(int.Parse(organizationId));
            } 
            else
            {
                Campaigns = _campaignRepository.GetCampaigns();
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}