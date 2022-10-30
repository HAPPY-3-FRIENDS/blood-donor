using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepositories;
using System;
using System.ComponentModel.DataAnnotations;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class RegisterModel : PageModel
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IVolunteerInCampaignRepository _volunteerInCampaignRepository;

        public RegisterModel(IVolunteerRepository volunteerRepository, IVolunteerInCampaignRepository volunteerInCampaignRepository)
        {
            _volunteerRepository = volunteerRepository;
            _volunteerInCampaignRepository = volunteerInCampaignRepository;
        }

        [BindProperty, Required]
        public string Phone { get; set; }

        [BindProperty, Required]
        public string Password { get; set; }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

        [BindProperty]
        public Campaign Campaign { get; set; }

        [BindProperty]
        public VolunteerInCampaign VolunteerInCampaign { get; set; }

        public IActionResult OnGet(int campaignId)
        {
            if (HttpContext.Session.GetString("role") == null)
            {
                HttpContext.Session.SetString("action", "RegisterCampaign");
                return RedirectToPage("/Login", new
                {
                    campaignId = campaignId
                });
            }
            else if (HttpContext.Session.GetString("role") == "Organization")
            {
                Volunteer = _volunteerRepository.GetVolunteerByPhone(HttpContext.Session.GetString("volunteerPhone"));

                if (Volunteer == null)
                {
                    return NotFound();
                }
            }
            else
            {
                Volunteer = _volunteerRepository.GetVolunteerByPhone(HttpContext.Session.GetString("phone"));

                if (Volunteer == null)
                {
                    return NotFound();
                }
            }

            return Page();
        }

        public IActionResult OnPostCampaignRegister(int campaignId)
        {
            string volunteerId = "";
            if (HttpContext.Session.GetString("role") == "Organization")
            {
                volunteerId = HttpContext.Session.GetString("volunteerPhone");
            } else if (HttpContext.Session.GetString("role") == "Volunteer")
            {
                volunteerId = HttpContext.Session.GetString("phone");
            }

            VolunteerInCampaign volunteerInCampaign = new VolunteerInCampaign
            {
                VolunteerId = volunteerId,
                CampaignId = Campaign.Id,
            };

            _volunteerInCampaignRepository.CreateVolunteerInCampaign(volunteerInCampaign);

            return RedirectToPage("/VolunteerInCampaigns/Index", new
            {
                campaignId = volunteerInCampaign.CampaignId,
            });
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
