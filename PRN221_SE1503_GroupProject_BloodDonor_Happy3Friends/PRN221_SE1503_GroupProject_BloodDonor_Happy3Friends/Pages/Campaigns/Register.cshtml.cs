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
        private readonly ICampaignRepository _campaignRepository;

        public RegisterModel(IVolunteerRepository volunteerRepository, IVolunteerInCampaignRepository volunteerInCampaignRepository, ICampaignRepository campaignRepository)
        {
            _volunteerRepository = volunteerRepository;
            _volunteerInCampaignRepository = volunteerInCampaignRepository;
            _campaignRepository = campaignRepository;
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
            else if (HttpContext.Session.GetString("role") == "Volunteer")
            {
                Volunteer = _volunteerRepository.GetVolunteerByPhone(HttpContext.Session.GetString("phone"));

                if (Volunteer == null)
                {
                    return NotFound();
                }
            }

            Campaign = _campaignRepository.GetCampaignById(campaignId);

            return Page();
        }

        public IActionResult OnPostCampaignRegister()
        { 
            try
            {
                string volunteerId = "";
                if (HttpContext.Session.GetString("role") == "Organization")
                {
                    volunteerId = HttpContext.Session.GetString("volunteerPhone");
                }
                else if (HttpContext.Session.GetString("role") == "Volunteer")
                {
                    volunteerId = HttpContext.Session.GetString("phone");
                }

                VolunteerInCampaign volunteerInCampaign = new VolunteerInCampaign
                {
                    VolunteerId = volunteerId,
                    CampaignId = Campaign.Id,
                };

                _volunteerInCampaignRepository.CreateVolunteerInCampaign(volunteerInCampaign);
            }
            catch (Exception ex)
            {
                TempData["Error"] = ex.Message;
                return RedirectToPage("/Campaigns/Register", new
                {
                    campaignId = Campaign.Id
                });
            }
            

            return RedirectToPage("/VolunteerInCampaigns/Index", new
            {
                campaignId = Campaign.Id
            });
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}
