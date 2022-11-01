using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BusinessObjects.Models;
using Repositories.IRepositories;
using Microsoft.AspNetCore.Http;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class DetailsModel : PageModel
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public DetailsModel(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        public Volunteer Volunteer { get; set; }

        public IActionResult OnGet()
        {
            string phone = HttpContext.Session.GetString("phone");
            Volunteer = _volunteerRepository.GetVolunteerByPhone(phone);

            if (Volunteer == null)
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