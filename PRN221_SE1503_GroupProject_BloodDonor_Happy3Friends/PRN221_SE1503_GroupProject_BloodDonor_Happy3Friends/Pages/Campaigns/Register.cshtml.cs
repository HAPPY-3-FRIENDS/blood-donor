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
        private readonly ICampaignRepository _campaignRepository;
        private readonly IVolunteerInCampaignRepository _volunteerInCampaignRepository;

        public RegisterModel(IVolunteerRepository volunteerRepository, ICampaignRepository campaignRepository, IVolunteerInCampaignRepository volunteerInCampaignRepository)
        {
            _volunteerRepository = volunteerRepository;
            _campaignRepository = campaignRepository;
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
            if (HttpContext.Session.GetString("role") == null || HttpContext.Session.GetString("role") != "Volunteer")
            {
                HttpContext.Session.SetString("action", "RegisterCampaign");
                return RedirectToPage("/Login", new
                {
                    campaignId = campaignId
                });
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

        public IActionResult OnPostCampaignRegister()
        {
            string volunteerId = HttpContext.Session.GetString("phone");
            DateTime registrationDate = DateTime.Now;
            string bloodType = _volunteerRepository.GetVolunteerByPhone(volunteerId).BloodType;

            VolunteerInCampaign volunteerInCampaign = new VolunteerInCampaign
            {
                VolunteerId = volunteerId,
                CampaignId = Campaign.Id,
                RegistrationDate = registrationDate,
                BloodType = bloodType
            };

            _volunteerInCampaignRepository.CreateVolunteerInCampaign(volunteerInCampaign);

            return RedirectToPage("/VolunteerInCampaigns/Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
