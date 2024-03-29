﻿using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.VolunteerInCampaigns
{
    public class DetailsModel : PageModel
    {
        private readonly IVolunteerInCampaignRepository _volunteerInCampaignRepository;

        public DetailsModel(IVolunteerInCampaignRepository volunteerInCampaignRepository)
        {
            _volunteerInCampaignRepository = volunteerInCampaignRepository;
        }

        public VolunteerInCampaign VolunteerInCampaign { get; set; }

        public IActionResult OnGet(int id)
        {
            VolunteerInCampaign = _volunteerInCampaignRepository.GetVolunteerInCampaignById(id);

            if (VolunteerInCampaign == null)
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
