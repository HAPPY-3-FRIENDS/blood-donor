using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using BusinessObjects.Models;

namespace PRN221_SE1503_GroupProject_BloodDonor_Happy3Friends.Pages.Volunteers
{
    public class EditModel : PageModel
    {
        private readonly PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext _context;

        public EditModel(PRN221_SE1503_GroupProject_BloodDonor_Happy3FriendsContext context)
        {
            _context = context;
        }

        [BindProperty]
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

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Volunteer).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
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

            return RedirectToPage("./Index");
        }

        private bool VolunteerExists(string id)
        {
            return _context.Volunteers.Any(e => e.Phone == id);
        }
    }
}