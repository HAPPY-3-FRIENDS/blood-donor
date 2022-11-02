using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;
using Repositories.IRepositories;
using Microsoft.AspNetCore.Http;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class EditModel : PageModel
    {
        private readonly IVolunteerRepository _volunteerRepository;

        public EditModel(IVolunteerRepository volunteerRepository)
        {
            _volunteerRepository = volunteerRepository;
        }

        [BindProperty]
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

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _volunteerRepository.UpdateVolunteer(Volunteer);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VolunteerExists(Volunteer.Phone))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Details");
        }

        private bool VolunteerExists(string id)
        {
            return _volunteerRepository.GetVolunteerByPhone(id) != null;
        }

        public IActionResult OnPostLogout()
        {
            HttpContext.Session.Clear();
            return RedirectToPage("/Index");
        }
    }
}