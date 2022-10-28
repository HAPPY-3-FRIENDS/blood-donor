using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepositories;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Campaigns
{
    public class RegisterModel : PageModel
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public RegisterModel(IVolunteerRepository volunteerRepository, IOrganizationRepository organizationRepository)
        {
            _volunteerRepository = volunteerRepository;
            _organizationRepository = organizationRepository;
        }

        [BindProperty, Required]
        public string Phone { get; set; }

        [BindProperty, Required]
        public string Password { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetString("role") == null && HttpContext.Session.GetString("role") != "Volunteer")
            {
                HttpContext.Session.SetString("action", "RegisterCampaign");
                return RedirectToPage("/Login");
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
