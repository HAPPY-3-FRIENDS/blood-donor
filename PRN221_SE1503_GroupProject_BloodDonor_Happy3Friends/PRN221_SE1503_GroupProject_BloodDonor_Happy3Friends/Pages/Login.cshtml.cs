using BusinessObjects.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Repositories.IRepositories;
using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IVolunteerRepository _volunteerRepository;
        private readonly IOrganizationRepository _organizationRepository;

        public LoginModel(IVolunteerRepository volunteerRepository, IOrganizationRepository organizationRepository)
        {
            _volunteerRepository = volunteerRepository;
            _organizationRepository = organizationRepository;
        }

        [BindProperty, Required]
        public string Phone { get; set; }

        [BindProperty, Required]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            string fileName = "appsettings.json";
            string json = System.IO.File.ReadAllText(fileName);

            var adminAccount = JsonSerializer.Deserialize<Admin>(json, null);

            string phoneAdmin = adminAccount.Phone;
            string passwordAdmin = adminAccount.Password;
            string roleAdmin = adminAccount.Role;

            bool isAdmin = false;
            if (phoneAdmin.Equals(Phone) && passwordAdmin.Equals(Password))
            {
                HttpContext.Session.SetString("phone", phoneAdmin);
                HttpContext.Session.SetString("role", roleAdmin);
                HttpContext.Session.SetString("name", "Admin");
                isAdmin = true;
                return RedirectToPage("/Organizations/Index");
            }

            if (!isAdmin)
            {
                bool isVolunteer = _volunteerRepository.CheckLogin(Phone, Password);
                if (isVolunteer)
                {
                    Volunteer volunteer = _volunteerRepository.GetVolunteerByPhone(Phone);
                    HttpContext.Session.SetString("phone", volunteer.Phone);
                    HttpContext.Session.SetString("role", "Volunteer");
                    HttpContext.Session.SetString("name", volunteer.Name);
                    if (HttpContext.Session.GetString("action") != null && HttpContext.Session.GetString("action") == "RegisterCampaign")
                    {
                        return RedirectToPage("/Campaigns/Register");
                    } 
                    else if (HttpContext.Session.GetString("action") != null && HttpContext.Session.GetString("action") == "RegisterCampaignsList")
                    {
                        return RedirectToPage("/Campaigns/Index");
                    }
                }
                else
                {
                    bool isOrganization = _organizationRepository.CheckLogin(Phone, Password);
                    if (isOrganization)
                    {
                        Organization organization = _organizationRepository.GetOrganizationByUserName(Phone);
                        HttpContext.Session.SetString("phone", organization.Id.ToString());
                        HttpContext.Session.SetString("role", "Organization");
                        HttpContext.Session.SetString("name", organization.Name);
                        return RedirectToPage("/Campaigns/Index");
                    }
                }
            }

            return RedirectToPage("/Index");
        }
    }
}