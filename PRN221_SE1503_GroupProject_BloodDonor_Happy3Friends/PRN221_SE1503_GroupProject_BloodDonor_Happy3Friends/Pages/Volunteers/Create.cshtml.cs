using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;
using System.Text.Json;
using Microsoft.AspNetCore.Http;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class CreateModel : PageModel
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public CreateModel(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Volunteer Volunteer { get; set; }

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

            Volunteer _volunteer = _volunteerRepository.GetVolunteerByPhone(Volunteer.Phone);

            if (Volunteer.Phone.Equals(phoneAdmin) || _volunteer != null)
            {
                ModelState.AddModelError("Volunteer.Phone", "Số điện thoại này đã được sử dụng bởi một tình nguyện viên khác!");
                return Page();
            }

            if (ModelState.IsValid)
            {
                _volunteerRepository.CreateVolunteer(Volunteer);
                if (HttpContext.Session.GetString("action") != null && HttpContext.Session.GetString("action") == "RegisterCampaign")
                {
                    return RedirectToPage("/Campaigns/Register");
                } else if (HttpContext.Session.GetString("action") != null && HttpContext.Session.GetString("action") == "RegisterCampaignsList") {
                    return RedirectToPage("/Campaigns/Index");
                }
                if (HttpContext.Session.GetString("role") == "Organization")
                {
                    return RedirectToPage("/Campaigns/Index");
                }
            }

            return RedirectToPage("/Index");
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}