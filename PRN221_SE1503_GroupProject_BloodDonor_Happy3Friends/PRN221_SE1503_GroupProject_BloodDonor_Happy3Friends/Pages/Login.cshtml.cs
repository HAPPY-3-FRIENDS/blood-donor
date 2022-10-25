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

        public LoginModel(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        [BindProperty, Required]
        public string Phone { get; set; }
        [BindProperty, Required]
        public string Password { get; set; }

        public IActionResult OnPost()
        {
            string fileName = "appsettings.json";
            string json = System.IO.File.ReadAllText(fileName);  // đọc text từ tập tin JSON

            // deserialize từ chuỗi đọc ở tập tin JSOn --> đối tượng DefaultAccount
            var adminAccount = JsonSerializer.Deserialize<Admin>(json, null);

            string phoneAdmin = adminAccount.Phone;
            string passwordAdmin = adminAccount.Password;
            string roleAdmin = adminAccount.Role;

            bool isAdmin = false;
            if (phoneAdmin.Equals(Phone) && passwordAdmin.Equals(Password))
            {
                HttpContext.Session.SetString("phone", phoneAdmin);
                HttpContext.Session.SetString("role", roleAdmin);
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
                    HttpContext.Session.SetString("name", volunteer.Name);
                    HttpContext.Session.SetString("role", "Volunteer");
                }
            }

            return RedirectToPage("/Index");
        }
    }
}
