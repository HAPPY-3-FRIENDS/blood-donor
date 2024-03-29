﻿using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Microsoft.AspNetCore.Mvc;
using Repositories.IRepositories;
using Microsoft.AspNetCore.Http;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class IndexModel : PageModel
    {
        private readonly IVolunteerInCampaignRepository _volunteerInCampaignRepository;
        private readonly ICampaignRepository _campaignRepository;

        public IndexModel(IVolunteerInCampaignRepository volunteerInCampaignRepository, ICampaignRepository campaignRepository)
        {
            _volunteerInCampaignRepository = volunteerInCampaignRepository;
            _campaignRepository = campaignRepository;
        }

        public IList<VolunteerInCampaign> VolunteerInCampaigns { get;set; }
        public Campaign Campaign { get; set; }

        public void OnGet(int campaignId)
        {
            if (HttpContext.Session.GetString("role") != null && HttpContext.Session.GetString("role") == "Volunteer")
            {
                VolunteerInCampaigns = _volunteerInCampaignRepository.GetVolunteerInCampaignsByVolunteerId(HttpContext.Session.GetString("phone"));
            } 
            if (HttpContext.Session.GetString("role") != null && HttpContext.Session.GetString("role") == "Organization")
            {
                VolunteerInCampaigns = _volunteerInCampaignRepository.GetVolunteerInCampaignsByCampaignId(campaignId);
                Campaign = _campaignRepository.GetCampaignById(campaignId);
            }
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}