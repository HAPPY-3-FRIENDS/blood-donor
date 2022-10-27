using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class DetailsModel : PageModel
    {
        private readonly PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public DetailsModel(PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        public Volunteer Volunteer { get; set; }

        public async Task<IActionResult> OnGetAsync(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Volunteer = await _context.Volunteers.FirstOrDefaultAsync(m => m.Phone == id);

            if (Volunteer == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}